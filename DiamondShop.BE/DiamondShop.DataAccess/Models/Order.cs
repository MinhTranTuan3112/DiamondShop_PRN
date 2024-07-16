namespace DiamondShop.DataAccess.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public int Point { get; set; }

    public int PromotionPercent { get; set; }

    public decimal Total { get; set; }

    public string? PayMethod { get; set; }

    public DateTime? ShipDate { get; set; }

    public string? ShipAddress { get; set; }

    public string? Note { get; set; }

    public string? Status { get; set; }

    public Guid CustomerId { get; set; }

    public Guid? SalesStaffId { get; set; }

    public Guid? DeliveryStaffId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual StakeHolder? DeliveryStaff { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual StakeHolder? SalesStaff { get; set; }
}
