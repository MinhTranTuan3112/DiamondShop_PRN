using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Enums;
using Microsoft.AspNetCore.Http;

namespace DiamondShop.DataAccess.DTOs.Diamond
{
    public class CreateDiamondDto
    {
        [Required]
        [EnumDataType(typeof(DiamondShape))]
        public required string Shape { get; set; }
        [Required]
        [EnumDataType(typeof(DiamondColor))]
        public required string Color { get; set; }

        [Required]
        [EnumDataType(typeof(DiamondOrigin))]
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
        
        [Required]
        public Guid CertificateId { get; set; }
        public List<IFormFile> DiamondImages { get; set; } = [];

    }
}