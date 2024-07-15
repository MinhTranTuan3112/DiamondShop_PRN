using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Promotion
{
    public class UpdatePromotion
    {
        public Guid Id { get; set; }
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
}
