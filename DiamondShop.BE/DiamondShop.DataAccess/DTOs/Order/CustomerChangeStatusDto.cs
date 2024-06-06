using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Order
{
    public class CustomerSendDto
    {
        [Required] public Guid CustomerId { get; set; }
        [Required] public Guid OrderId { get; set; }
        [Required] public required string Status { get; set; }
        public string? ShipAddress { get; set; }
        public string? Note { get; set; }
    }
}
