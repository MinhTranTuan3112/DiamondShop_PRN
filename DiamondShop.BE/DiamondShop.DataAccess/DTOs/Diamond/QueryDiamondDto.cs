using DiamondShop.DataAccess.DTOs.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.DataAccess.DTOs.Diamond
{
    public class QueryDiamondDto
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
        public decimal? StartPrice { get; set; }

        [FromQuery(Name = "endPrice")]
        public decimal? EndPrice { get; set; }

        // [FromQuery(Name = "name")]
        // public string? Name { get; set; }


        [FromQuery(Name = "colors")]
        public List<string> Colors { get; set; } = [];


        [FromQuery(Name = "cuts")]
        public List<string> Cuts { get; set; } = [];

        [FromQuery(Name = "clarities")]
        public List<string> Clarities { get; set; } = [];
    }
}
