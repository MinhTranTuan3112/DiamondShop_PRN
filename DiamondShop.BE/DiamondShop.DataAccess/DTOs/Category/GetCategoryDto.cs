using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Category
{
    public class GetCategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
    }
}