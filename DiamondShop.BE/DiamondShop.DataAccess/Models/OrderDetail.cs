using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class OrderDetail
{
    public Guid Id { get; set; }

    public int? Quantity { get; set; }

    public decimal? SubTotal { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ProductId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<Warranty> Warranties { get; set; } = new List<Warranty>();
}
