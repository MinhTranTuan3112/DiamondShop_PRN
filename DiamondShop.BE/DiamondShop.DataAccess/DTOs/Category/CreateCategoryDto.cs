using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Category
{
    public class CreateCategoryDto
    {
        [MaxLength(255)]
        [Required]
        public required string Name { get; set; }
        
    }
}
