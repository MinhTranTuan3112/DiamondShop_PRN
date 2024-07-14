using DiamondShop.DataAccess.DTOs.Customer;
using DiamondShop.DataAccess.DTOs.StakeHolder;

namespace DiamondShop.DataAccess.DTOs.Account;

public class GetAccountDto
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? AvatarUrl { get; set; }

    public string Role { get; set; } = null!;

    public string? Status { get; set; }
    
    public GetCustomerDto? Customer { get; set; }
    public GetStakeHolderDto? StakeHolder { get; set; }
}