using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Category
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime? LastUpdate { get; set; }

        public string? Status { get; set; }
    }
}
