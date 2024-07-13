using DiamondShop.DataAccess.DTOs.Query;

namespace DiamondShop.DataAccess.DTOs.Certificate;

public class QueryCertificateDto
{
    public QueryDto QueryDto { get; set; } = new QueryDto();
    public string? ReportNumber { get; set; }
    public DateTime StartDateOfIssue { get; set; }
    public DateTime EndDateOfIssue { get; set; }
    public Guid? DiamondId { get; set; }
    
}