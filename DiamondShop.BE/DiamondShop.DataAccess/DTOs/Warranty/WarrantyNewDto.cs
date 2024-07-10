using DiamondShop.DataAccess.Enums;

namespace DiamondShop.DataAccess.DTOs.Warranty
{
    public class WarrantyNewDto
    {
        public Guid OrderDetailId {get;set;}
        public string ItemName { get; set; } = null!;
        public WarrantyType Type { get; set; }
        public string? Privacy { get; set; }
        public string? Condition { get; set; }
        public string? Reason { get; set; }
    }
}
