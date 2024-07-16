using DiamondShop.DataAccess.Enums;

namespace DiamondShop.DataAccess.DTOs.Warranty
{
    public class WarrantyUpdateDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string? Type { get; set; }
        public string? Privacy { get; set; }
        public string? Condition { get; set; }
        public DateTime StartDate { get; set; }
        public string? Reason { get; set; }
        required public WarrantyStatus Status { get; set; }
    }
}
