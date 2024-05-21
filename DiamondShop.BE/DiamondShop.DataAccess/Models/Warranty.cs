using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class Warranty
{
    public Guid Id { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsValid { get; set; }

    public bool? IsApply { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
