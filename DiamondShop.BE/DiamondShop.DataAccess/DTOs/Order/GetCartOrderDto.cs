using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.OrderDetail;

namespace DiamondShop.DataAccess.DTOs.Order
{
    public class GetCartOrderDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public string? PayMethod { get; set; }

        public DateTime? ShipDate { get; set; }

        public string? ShipAddress { get; set; }

        public string? Note { get; set; }

        public string? Status { get; set; }

        public Guid CustomerId { get; set; }

        public ICollection<GetOrderDetailsInCartDto> OrderDetails { get; set; } = [];

    }
}