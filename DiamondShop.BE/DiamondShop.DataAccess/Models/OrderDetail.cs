using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class OrderDetail
{
    public int? Quantity { get; set; }

    public decimal? SubTotal { get; set; }

    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public Guid WarrantyId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Warranty Warranty { get; set; } = null!;
}
