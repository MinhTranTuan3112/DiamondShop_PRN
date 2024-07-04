using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Query;

namespace DiamondShop.DataAccess.DTOs.Product
{
    public class QueryProductDto
    {
        public QueryDto QueryDto { get; set; } = new QueryDto();
        public decimal StartPrice { get; set; }
        public decimal EndPrice { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Guid> CategoryIds { get; set; } = [];
        public string? Material { get; set; }
        public List<Guid> DiamondIds { get; set; } = [];
    }
}