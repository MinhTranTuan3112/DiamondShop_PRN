namespace DiamondShop.DataAccess.Models;

public partial class CustomerPromotion
{
    public Guid PromotionId { get; set; }

    public Guid CustomerId { get; set; }

    public DateTime CollectedDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Promotion Promotion { get; set; } = null!;
}
