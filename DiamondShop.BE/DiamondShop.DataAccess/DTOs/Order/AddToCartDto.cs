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
        public required int Quantity { get; set; }

        [Required]
        public required Guid ProductId { get; set; }

        public decimal RingSize { get; set; } = 0;

        public decimal RingSizePrice { get; set; }= 0;

    }
}