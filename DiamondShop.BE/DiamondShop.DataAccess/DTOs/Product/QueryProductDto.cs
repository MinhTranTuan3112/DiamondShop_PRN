using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Query;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.DataAccess.DTOs.Product
{
    public class QueryProductDto
    {

        [FromQuery(Name = "pageNumber")]
        public int PageNumber { get; set; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = 10;

        [FromQuery(Name = "sortColumn")]
        public string SortColumn { get; set; } = "id";

        [FromQuery(Name = "orderByDesc")]
        public bool OrderByDesc { get; set; } = false;
        
        [FromQuery(Name = "startPrice")]
        public decimal StartPrice { get; set; }

        [FromQuery(Name = "endPrice")]
        public decimal EndPrice { get; set; }

        [FromQuery(Name = "name")]
        public string Name { get; set; } = string.Empty;

        [FromQuery(Name = "categoryIds")]
        public List<Guid> CategoryIds { get; set; } = [];
        
        [FromQuery(Name = "material")]
        public string? Material { get; set; }
        
        [FromQuery(Name = "diamondIds")]
        public List<Guid> DiamondIds { get; set; } = [];
    }
}