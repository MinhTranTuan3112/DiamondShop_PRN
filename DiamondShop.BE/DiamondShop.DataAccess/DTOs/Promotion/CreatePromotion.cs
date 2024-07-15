using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Promotion
{
    public class CreatePromotion
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; } = DateTime.Now;
        [Required]
        public int DiscountPercent { get; set; }
        [Required]
        public PromotionStatus Status { get; set; }
    }

    public enum PromotionStatus
    {
        Active,
        Inactive
    }
}
