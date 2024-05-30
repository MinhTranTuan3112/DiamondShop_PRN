using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Query
{
    public record QueryDto(
        int PageNumber = 1,
        int PageSize = 10,
        string SortBy = "id",
        bool OrderByDesc = false
    );
}