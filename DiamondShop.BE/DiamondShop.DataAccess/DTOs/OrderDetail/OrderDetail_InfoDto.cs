using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.OrderDetail
{
    public class OrderDetail_InfoDto
    {
        public Guid OrderDetailId { get; set; }
        public Guid? ProductId { get; set; } = Guid.Empty;
        public Guid? DiamondId { get; set; } = Guid.Empty;
        public bool? ComplexProduction { get; set; }
        public int Quantity { get; set; } = 0;
        public string? RingSize { get; set; }
        public decimal SumSizePrice { get; set; } = 0;
        public decimal SubTotal { get; set; } = 0;
    }
}
