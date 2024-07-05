namespace DiamondShop.DataAccess.DTOs.StakeHolder;

public class GetStakeHolderDto
{
    public Guid Id { get; set; }

    public string? Fullname { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public decimal Salary { get; set; }

    public DateOnly? DateHired { get; set; }
}