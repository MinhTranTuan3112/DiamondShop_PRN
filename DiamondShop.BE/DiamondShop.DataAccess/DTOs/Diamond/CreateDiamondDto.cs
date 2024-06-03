using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.DataAccess.DTOs.Diamond
{
    public class CreateDiamondDto
    {
        [MaxLength(255)]
        [Required]
        public required string Name { get; set; }
        
        [Required]
        [EnumDataType(typeof(DiamondColor))]
        public required string Color { get; set; }

        [Required]
        public required string Origin { get; set; }

        [Required]
        public required string CaratWeight { get; set; }

        [Required]
        [EnumDataType(typeof(DiamondClarity))]
        public required string Clarity { get; set; }

        [Required]
        [EnumDataType(typeof(DiamondCut))]
        public required string Cut { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int WarrantyPeriod { get; set; }
    }
}