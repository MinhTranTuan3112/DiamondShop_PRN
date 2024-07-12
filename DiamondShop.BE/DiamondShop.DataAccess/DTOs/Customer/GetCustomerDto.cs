namespace DiamondShop.DataAccess.DTOs.Customer;

public class GetCustomerDto
{
    public Guid Id { get; set; }

    public string? Fullname { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public int Point { get; set; }
}