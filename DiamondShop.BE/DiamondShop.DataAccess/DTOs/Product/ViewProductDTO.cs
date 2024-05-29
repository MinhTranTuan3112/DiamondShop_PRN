using DiamondShop.DataAccess.DTOs.Category;
using DiamondShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Product
{
    public class ViewProductDTO
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

        public CategoryDTO? Category { get; set; }
    }
}
