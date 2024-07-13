namespace DiamondShop.DataAccess.DTOs.Certificate;

public class GetListCertificateDto
{
    public Guid Id { get; set; }
    public string? ReportNumber { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string? Status { get; set; }
}