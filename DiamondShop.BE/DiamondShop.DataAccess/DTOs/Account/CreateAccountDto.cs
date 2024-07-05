using System.ComponentModel.DataAnnotations;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.DataAccess.DTOs.Account;

public class CreateAccountDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    [EnumDataType(typeof(Role))]
    public required string Role { get; set; }
    [Required]
    public required string FullName { get; set; }
}