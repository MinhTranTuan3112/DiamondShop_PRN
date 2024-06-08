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

        public async Task<GetAccountDto> GetAccountInfoByClaims(ClaimsPrincipal claims)
        {
            var accountId = claims.GetAccountId();

            var account = await _unitOfWork.GetAccountRepository().FindOneAsync(a => a.Id == accountId);

            if (account is null)
            {
                throw new UnauthorizedException("Unauthorized");
            }

            return account.Adapt<GetAccountDto>();

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
            registerDto.Password = HashPassword(registerDto.Password);
            var account = await _unitOfWork.GetAccountRepository().AddAsync(registerDto.Adapt<Account>());
            await _unitOfWork.SaveChangesAsync();

            switch (account.Role)
            {
                case var role when role == Role.Customer.ToString():
                    await _unitOfWork.GetCustomerRepository().AddAsync(new Customer
                    {
                        AccountId = account.Id,
                        Fullname = string.Empty
                    });

                    await _unitOfWork.SaveChangesAsync();
                    break;
                default:
                    throw new BadRequestException("Invalid role or this role is not supported yet.");

            }
        }
    }
}