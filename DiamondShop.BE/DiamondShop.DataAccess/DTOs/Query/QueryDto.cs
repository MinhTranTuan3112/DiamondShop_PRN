using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Query
{
    public record struct QueryDto(int PageNumber = 1, int PageSize = 10, string SortBy = "id", bool OrderByDesc = false)
    {
        // public int PageNumber { get; set; }

        // public int PageSize { get; set; }

        // public string SortBy { get; set; } = "id";

        // public bool OrderByDesc { get; set; } = false;

    }
}