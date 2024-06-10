using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Enums;
using Microsoft.AspNetCore.Http;

namespace DiamondShop.DataAccess.DTOs.Diamond
{
    public class UpdateDiamondDto
    {
        public string? Name { get; set; }

        [EnumDataType(typeof(DiamondColor))]
        public string? Color { get; set; }

        public string? Origin { get; set; }

        public string? CaratWeight { get; set; }

        [EnumDataType(typeof(DiamondClarity))]
        public string? Clarity { get; set; }

        [EnumDataType(typeof(DiamondCut))]
        public string? Cut { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public int? WarrantyPeriod { get; set; }

        public string? Status { get; set; }

        public List<IFormFile> DiamondImages { get; set; } = [];
    }
}