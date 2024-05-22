using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public AuthController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost("login")]
        public async Task<ActionResult<GetAuthTokenDto>> Login([FromBody] LoginDto loginDto)
        {
            return Created(nameof(Login), await _serviceFactory.GetAuthService().Login(loginDto));
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _serviceFactory.GetAuthService().Register(registerDto);
            return Ok();
        }

        [HttpGet("who-am-i")]
        [Authorize]
        public async Task<ActionResult<GetAccountDto>> WhoAmI()
        {
            return await _serviceFactory.GetAuthService().GetAccountInfoByClaims(HttpContext.User);
        }
    }
}