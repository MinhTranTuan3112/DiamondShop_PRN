using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Order
{
    public class AddToCartDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public required int Quantity { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? DiamondId { get; set; }

        public int? RingSize { get; set; }

        public decimal SumSizePrice { get; set; } = 0;

    }
}