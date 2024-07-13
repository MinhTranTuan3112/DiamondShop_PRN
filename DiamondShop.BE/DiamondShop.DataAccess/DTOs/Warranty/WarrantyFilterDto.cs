using DiamondShop.DataAccess.Enums;

namespace DiamondShop.DataAccess.DTOs.Warranty
{
    public class WarrantyFilterDto
    {
        public int Size { get; set; } = 10;
        public int Page { get; set; } = 1;
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? ItemName { get; set; }
        public bool? IsProduct { get; set; }
        public string? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public WarrantyStatus Status { get; set; }
        public bool IsDescending { get; set; }//By date
    }
}
