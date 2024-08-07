﻿using System.ComponentModel.DataAnnotations;
using DiamondShop.DataAccess.Enums;
using Microsoft.AspNetCore.Http;

namespace DiamondShop.DataAccess.DTOs.Product;

public class UpdateProductDto
{
    public string? Name { get; set; }
    [EnumDataType(typeof(ProductType))]
    public string? Type { get; set; }
    public string? Material { get; set; }
    public bool? Gender { get; set; }
    public decimal? Price { get; set; }
    public int? Point { get; set; }
    public int? Quantity { get; set; }
    public int? WarrantyPeriod { get; set; }
    public Guid? CategoryId { get; set; } 
    public List<IFormFile> ProductPicture { get; set; } = [];
}