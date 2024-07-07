using Microsoft.AspNetCore.Http;

namespace DiamondShop.DataAccess.DTOs.Account;

public class UpdateAccountDto
{
    public IFormFile? Image { get; set; }
    public string? Fullname { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal Salary { get; set; }
}