using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces;

public interface IAccountService
{
    Task UpdateAccount(Guid id, UpdateAccountDto updateAccountDto);
    Task<List<GetAccountDto>> GetAllAccounts();
    Task<GetAccountDetailDto> GetAccountById(Guid id);
    Task ChangeAccountStatus(Guid accountId, AccountStatus status);
}