using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.DTOs.Auth;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        Task<GetAuthTokenDto> Login(LoginDto loginDto);

        Task Register(RegisterDto registerDto);

        Task<GetAccountDto> GetAccountInfoByClaims(ClaimsPrincipal claims);
    }
}