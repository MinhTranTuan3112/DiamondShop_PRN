using DiamondShop.DataAccess.DTOs.Diamond;

namespace DiamondShop.DataAccess.DTOs.Certificate;

public class GetCertificateByIdDto
{
    public Guid Id { get; set; }

    public string? ReportNumber { get; set; }

    public string? Origin { get; set; } 

    public string? Shape { get; set; }

    public string? Color { get; set; } 

    public string? Clarity { get; set; } 

    public string? Cut { get; set; } 

    public string? CaratWeight { get; set; } 

    public DateTime DateOfIssue { get; set; }

    public string? Status { get; set; }
    
    public GetDiamondDto? Diamond { get; set; }
}