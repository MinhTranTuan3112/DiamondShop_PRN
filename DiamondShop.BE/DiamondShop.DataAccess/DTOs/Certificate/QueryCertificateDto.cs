using DiamondShop.DataAccess.DTOs.Query;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.DataAccess.DTOs.Certificate;

public class QueryCertificateDto
{
    [FromQuery(Name = "pageNumber")]
    public int PageNumber { get; set; } = 1;

    [FromQuery(Name = "pageSize")]
    public int PageSize { get; set; } = 10;

    [FromQuery(Name = "sortColumn")]
    public string SortColumn { get; set; } = "id";

    [FromQuery(Name = "orderByDesc")]
    public bool OrderByDesc { get; set; } = false;
    [FromQuery(Name = "reportNumber")]
    public string? ReportNumber { get; set; }
    [FromQuery(Name = "startDateOfIssue")]
    public DateTime StartDateOfIssue { get; set; }
    [FromQuery(Name = "endDateOfIssue")]
    public DateTime EndDateOfIssue { get; set; }
    [FromQuery(Name = "diamondId")]
    public Guid? DiamondId { get; set; }
    
}