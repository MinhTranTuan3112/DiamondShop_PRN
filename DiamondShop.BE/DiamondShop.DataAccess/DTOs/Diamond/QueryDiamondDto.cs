using DiamondShop.DataAccess.DTOs.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Diamond
{
    public class QueryDiamondDto
    {
        public QueryDto QueryDto { get; set; } = new QueryDto();
        public decimal StartPrice { get; set; }
        public decimal EndPrice { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Origin { get; set; }
        public string? CaratWeight { get; set; }
        public string? Clarity { get; set; }
        public string? Cut { get; set; }
        
    }
}
