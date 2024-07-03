using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.OrderDetail
{
    public class OrderDetail_InfoDto
    {
        public int Size {  get; set; }
        public int Page { get; set; }
        public Guid OrderId { get; set; } = Guid.Empty;
        public Guid ProductId { get; set; } = Guid.Empty;
        public Guid DiamondId { get; set; } = Guid.Empty;
        public bool? ComplexProduction { get; set; }
        public int Quantity { get; set; } = 0;
        public string? RingSize { get; set; }
        public decimal SumSizePrice { get; set; } = 0;
        public decimal SubTotal { get; set; } = 0;
    }
}
