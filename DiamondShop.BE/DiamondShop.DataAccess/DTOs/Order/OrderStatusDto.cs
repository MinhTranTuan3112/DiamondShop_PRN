using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Order
{
    public class OrderStatusDto
    {
        [Required] public Guid Id { get; set; }
        [Required] public string Status { get; set; }
    }
}
