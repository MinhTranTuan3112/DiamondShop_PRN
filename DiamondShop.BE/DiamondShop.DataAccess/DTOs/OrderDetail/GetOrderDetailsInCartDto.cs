using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;

namespace DiamondShop.DataAccess.DTOs.OrderDetail
{
    public class GetOrderDetailsInCartDto
    {

        public Guid Id { get; set; }

        public bool? ComplexProduction { get; set; }

        public int Quantity { get; set; }

        public string? RingSize { get; set; }

        public decimal SumSizePrice { get; set; }

        public decimal SubTotal { get; set; }

        public string? Status { get; set; }

        public Guid OrderId { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? DiamondId { get; set; }

        public GetDiamondDto? Diamond { get; set; }

        public GetProductInPagedResultDto? Product { get; set; }

    }
}