using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DiamondShop.BusinessLogic.Extensions;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.DTOs.Auth;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DiamondShop.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<GetAccountDetailDto> GetAccountInfoByClaims(ClaimsPrincipal claims)
        {
            var accountId = claims.GetAccountId();

            var account = await _unitOfWork.GetAccountRepository().GetAccountDetail(accountId);

            if (account is null)
            {
                throw new UnauthorizedException("Unauthorized");
            }

            return account.Adapt<GetAccountDetailDto>();

        }

        public async Task CreateAccount(CreateAccountDto createAccountDto)
        {
            createAccountDto.Password = HashPassword(createAccountDto.Password);
            var account = await _unitOfWork.GetAccountRepository().AddAsync(createAccountDto.Adapt<Account>());
            await _unitOfWork.SaveChangesAsync();

            switch (account.Role)
            {
                case nameof(Role.Customer):
                    account.Status = AccountStatus.Working.ToString().ToLower();
                    await _unitOfWork.GetCustomerRepository().AddAsync(new Customer
                    {
                        AccountId = account.Id,
                        Fullname = createAccountDto.FullName
                    });
                    break;
                case nameof(Role.Manager):
                case nameof(Role.Admin):
                case nameof(Role.DeliveryStaff):
                case nameof(Role.SalesStaff):
                    await _unitOfWork.GetStakeHolderRepository().AddAsync(new StakeHolder
                    {
                        AccountId = account.Id,
                        Fullname = createAccountDto.FullName
                    });
                    break;
            } 
            await _unitOfWork.SaveChangesAsync();
        }

        

        public async Task UpdatePassword(Guid id, UpdatePasswordDto updatePasswordDto)
        {
            var account = await _unitOfWork.GetAccountRepository().FindOneAsync(x => x.Id == id);
            if (account is null)
            {
                throw new NotFoundException("Account is not existed");
            }
            if (HashPassword(updatePasswordDto.CurrentPassword) != account.Password)
            {
                throw new UnauthorizedException("Current password is not correct");
            }
            if (updatePasswordDto.RetypeNewPassword != updatePasswordDto.NewPassword)
            {
                throw new BadRequestException("Retype password does not match new password");
            }
            account.Password = HashPassword(updatePasswordDto.NewPassword);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<GetAuthTokenDto> Login(LoginDto loginDto)
        {
            var account = await _unitOfWork.GetAccountRepository().FindOneAsync(a => a.Email == loginDto.Email
            && a.Password == HashPassword(loginDto.Password));

            if (account is null)
            {
                throw new UnauthorizedException("Wrong email or password");
            }

            return GenerateAccessToken(account.Id, account.Role);
        }

        private GetAuthTokenDto GenerateAccessToken(Guid accountId, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuth:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>(){
                new(ClaimTypes.Role, role),
                new("aid", accountId.ToString())
            };

            var expireTime = DateTime.Now.AddDays(7);

            var token = new JwtSecurityToken(
              issuer: _configuration["JwtAuth:Issuer"],
              audience: _configuration["JwtAuth:Audience"],
              claims: claims,
              expires: expireTime,
              signingCredentials: credentials
            );

            return new GetAuthTokenDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireIn = expireTime
            };
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();

            // Convert the password string to bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Compute the hash
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // Convert the hash to a hexadecimal string
            string hashedPassword = string.Concat(hashBytes.Select(b => $"{b:x2}"));

            return hashedPassword;
        }



        public async Task Register(RegisterDto registerDto)
        {
            var accountDb = await _unitOfWork.GetAccountRepository().FindOneAsync(x => x.Email == registerDto.Email);
            if (accountDb is not null)
            {
                throw new BadRequestException("Email is already existed");
            }
            registerDto.Password = HashPassword(registerDto.Password);
            var account = await _unitOfWork.GetAccountRepository().AddAsync(registerDto.Adapt<Account>());
            account.Role = Role.Customer.ToString();
            
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.GetCustomerRepository().AddAsync(new Customer()
            {
                AccountId = account.Id,
                Fullname = registerDto.Fullname
            });
            await _unitOfWork.SaveChangesAsync();
            // switch (account.Role)
            // {
            //     case var role when role == Role.Customer.ToString():
            //         await _unitOfWork.GetCustomerRepository().AddAsync(new Customer
            //         {
            //             AccountId = account.Id,
            //             Fullname = string.Empty
            //         });
            //
            //         await _unitOfWork.SaveChangesAsync();
            //         break;
            //     default:
            //         throw new BadRequestException("Invalid role or this role is not supported yet.");
            //
            // }
        }
    }
}