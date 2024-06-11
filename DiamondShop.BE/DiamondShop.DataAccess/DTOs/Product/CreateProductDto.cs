﻿using DiamondShop.DataAccess.DTOs.ProductPart;
using DiamondShop.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Picture;
using Microsoft.AspNetCore.Http;

namespace DiamondShop.DataAccess.DTOs.Product
{
    public class CreateProductDto
    {
        [MaxLength(255)]
        [Required]
        public required string Name { get; set; }
        [MaxLength(255)]
        [Required]
        [EnumDataType(typeof(ProductType))]
        public required string Type { get; set; }
        [MaxLength(255)]
        [Required]
        public required string Material { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Point { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int WarrantyPeriod { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

        public List<IFormFile> Pictures { get; set; } = [];
    }
}
