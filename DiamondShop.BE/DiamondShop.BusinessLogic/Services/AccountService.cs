using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.Shared.Exceptions;
using Mapster;

namespace DiamondShop.BusinessLogic.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceFactory _serviceFactory;

    public AccountService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory)
    {
        _unitOfWork = unitOfWork;
        _serviceFactory = serviceFactory;

    }
    public async Task UpdateAccount(Guid id, UpdateAccountDto updateAccountDto)
            {
                var account = await _unitOfWork.GetAccountRepository().GetAccountDetail(id);
                if (account is null)
                {
                    throw new NotFoundException("Account is not existed");
                }
                var customer = account.Customer;
                var stakeHolder = account.StakeHolder;
                if (updateAccountDto.Image is not null)
                {
                    account.AvatarUrl = await _serviceFactory.GetFirebaseStorageService()
                        .UploadImageAsync(updateAccountDto.Image);
                }
                else
                {
                    account.AvatarUrl = null;
                }
    
                if (customer is not null)
                {
                    updateAccountDto.Adapt(customer);
                    
                }
    
                if (stakeHolder is not null)
                {
                    updateAccountDto.Adapt(stakeHolder);
                }
    
                await _unitOfWork.SaveChangesAsync();
            }

    public async Task<List<GetAccountDto>> GetAllAccounts()
    {
        var accounts = await _unitOfWork.GetAccountRepository().GetAllAsync();
        return accounts.Adapt<List<GetAccountDto>>();
    }

    public async Task<GetAccountDetailDto> GetAccountById(Guid id)
    {
        var account = await _unitOfWork.GetAccountRepository().GetAccountDetail(id);
        if (account is null)
        {
            throw new NotFoundException("Account is not existed");
        }

        return account.Adapt<GetAccountDetailDto>();
    }

    public async Task ChangeAccountStatus(Guid accountId, AccountStatus status)
    {
        var account = await _unitOfWork.GetAccountRepository().FindOneAsync(x => x.Id == accountId);
        if (account is null)
        {
            throw new NotFoundException("Account is not existed");
        }

        account.Status = status switch
        {
            AccountStatus.Available => AccountStatus.Available.ToString(),
            AccountStatus.Deleted => AccountStatus.Deleted.ToString(),
            _ => account.Status
        };
        await _unitOfWork.SaveChangesAsync();
    }
}