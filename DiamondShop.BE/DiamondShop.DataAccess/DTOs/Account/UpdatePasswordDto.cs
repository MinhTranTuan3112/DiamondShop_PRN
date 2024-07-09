using System.ComponentModel.DataAnnotations;

namespace DiamondShop.DataAccess.DTOs.Account;

public class UpdatePasswordDto
{
    [Required]
    public required string CurrentPassword { get; set; }
    [Required]
    public required string NewPassword { get; set; }
    [Required]
    public required string RetypeNewPassword { get; set; }
}