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

            return new GetAuthTokenDto
            {
                AccessToken = GenerateAccessToken(account.Id, account.Role)
            };

        }

        private string GenerateAccessToken(Guid accountId, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuth:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>(){
                new(ClaimTypes.Role, role),
                new("aid", accountId.ToString())
            };

            var token = new JwtSecurityToken(
              issuer: _configuration["JwtAuth:Issuer"],
              audience: _configuration["JwtAuth:Audience"],
              claims: claims,
              expires: DateTime.Now.AddDays(7),
              signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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
            var account = registerDto.Adapt<Account>();
            account.Password = HashPassword(registerDto.Password);
            await _unitOfWork.GetAccountRepository().AddAsync(account);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}