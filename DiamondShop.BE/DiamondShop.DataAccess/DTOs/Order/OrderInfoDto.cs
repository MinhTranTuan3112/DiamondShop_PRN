using System.ComponentModel.DataAnnotations;

namespace DiamondShop.DataAccess.DTOs.Order
{
    public class OrderInfoDto
    {
        [Required] public Guid OrderId { get; set; }
        public Guid SalesStaffId { get; set; } = Guid.Empty;
        public Guid DeliveryStaffId { get; set; } = Guid.Empty;
        public string? Code { get; set; }
        public decimal Total { get; set; } = 0;
        public string? ShipAddress { get; set; }
        public string? Note { get; set; }
    }
}
