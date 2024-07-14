using DiamondShop.DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.DataAccess.DTOs.Account;

public class QueryAccountDto
{
    [FromQuery(Name = "pageNumber")]
    public int PageNumber { get; set; } = 1;

    [FromQuery(Name = "pageSize")]
    public int PageSize { get; set; } = 10;

    [FromQuery(Name = "sortColumn")]
    public string SortColumn { get; set; } = "id";

    [FromQuery(Name = "orderByDesc")]
    public bool OrderByDesc { get; set; } = false;
    
    [FromQuery(Name = "role")]
    public Role? Role { get; set; }
    [FromQuery(Name = "email")]
    public string? Email { get; set; }
    [FromQuery(Name = "fullName")]
    public string? FullName { get; set; }
    
}