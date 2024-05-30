using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Query
{
    public class PagedResult<T> where T : class
    {
        public int TotalCount { get; set; }
        
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public List<T> Results { get; set; } = [];

    }
}