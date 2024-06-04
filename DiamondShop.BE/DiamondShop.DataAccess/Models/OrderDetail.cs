﻿using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class OrderDetail
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public string? RingSize { get; set; }

    public decimal SumSizePrice { get; set; }

    public decimal SubTotal { get; set; }

    public Guid OrderId { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? DiamondId { get; set; }

    public virtual Diamond? Diamond { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product? Product { get; set; }

    public virtual ICollection<Warranty> Warranties { get; set; } = new List<Warranty>();
}
