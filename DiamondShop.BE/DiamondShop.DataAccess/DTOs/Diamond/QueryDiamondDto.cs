using DiamondShop.DataAccess.DTOs.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.DataAccess.DTOs.Diamond
{
    public class QueryDiamondDto
    {
        public QueryDto QueryDto { get; set; } = new QueryDto();
        public decimal StartPrice { get; set; }
        public decimal EndPrice { get; set; }
        public string? Name { get; set; }
        public List<string> Colors { get; set; } = [];
        public List<string> Cuts { get; set; } = [];
        public List<string> Clarities { get; set; } = [];
    }
}
