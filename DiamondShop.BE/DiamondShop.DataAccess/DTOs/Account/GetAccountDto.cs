namespace DiamondShop.DataAccess.DTOs.Account;

public class GetAccountDto
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    //public string? Password { get; set; }

    public string? AvatarUrl { get; set; }

    //public DateTime? TimeStamp { get; set; }

    public string Role { get; set; } = null!;

    public string? Status { get; set; }
}