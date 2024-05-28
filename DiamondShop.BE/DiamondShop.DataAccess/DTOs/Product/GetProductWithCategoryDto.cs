using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Category;

namespace DiamondShop.DataAccess.DTOs.Product
{
    public class GetProductWithCategoryDto
    {
        public Guid Id { get; set; }

        public string? Material { get; set; }

        public bool? Gender { get; set; }

        public decimal? Price { get; set; }

        public int? Point { get; set; }

        public int? Quantity { get; set; }

        public int? WarrantyPeriod { get; set; }

        public DateTime? LastUpdate { get; set; }

        public string? Status { get; set; }

        public Guid CategoryId { get; set; }

        public GetCategoryDto Category { get; set; } = null!;
    }
}