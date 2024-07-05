using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
        {//Admin   Manager   SalesStaff   DeliveryStaff   Customer
            await _serviceFactory.GetAuthService().Register(registerDto);
            return Ok();
        }
        [HttpPost("create-account")]
        public async Task<ActionResult> CreateAccount([FromBody] CreateAccountDto createAccountDto)
        {
            await _serviceFactory.GetAuthService().CreateAccount(createAccountDto);
            return Ok();
        }
        
        [HttpPut("update-password/{id:guid}")]
        public async Task<ActionResult> UpdatePassword(Guid id, [FromBody]UpdatePasswordDto updatePasswordDto)
        {
            await _serviceFactory.GetAuthService().UpdatePassword(id, updatePasswordDto);
            return Ok();
        }
        [HttpGet("who-am-i")]
        [Authorize]
        public async Task<ActionResult<GetAccountDetailDto>> WhoAmI()
        {
            return await _serviceFactory.GetAuthService().GetAccountInfoByClaims(HttpContext.User);
        }
    }
}