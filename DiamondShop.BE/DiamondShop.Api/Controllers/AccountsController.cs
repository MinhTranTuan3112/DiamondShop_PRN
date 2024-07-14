using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public AccountsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAccount(Guid id, [FromForm]UpdateAccountDto updateAccountDto)
        {
            await _serviceFactory.GetAccountService().UpdateAccount(id, updateAccountDto);
            return NoContent();
        }
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetAccountDetailDto>> GetAccountById(Guid id)
        {
            return await _serviceFactory.GetAccountService().GetAccountById(id);

        }
        [HttpPut("{accountId:guid}/{status}")]
        public async Task<ActionResult> ChangeStatusAccount(Guid accountId, AccountStatus status)
        {
            await _serviceFactory.GetAccountService().ChangeAccountStatus(accountId, status);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetAccountDto>>> GetPagedProducts([FromQuery] QueryAccountDto queryAccountDto)
        {
            return await _serviceFactory.GetAccountService().GetPagedAccounts(queryAccountDto);
        }
    }
}
