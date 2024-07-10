﻿using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class Diamond
{
    public Guid Id { get; set; }

    public string Origin { get; set; } = null!;

    public string Shape { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Clarity { get; set; } = null!;

    public string Cut { get; set; } = null!;

    public string CaratWeight { get; set; } = null!;

    public int Point { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int WarrantyPeriod { get; set; }

    public DateTime LastUpdate { get; set; }

    public string Status { get; set; } = null!;

    public Guid CertificateId { get; set; }

    public virtual Certificate Certificate { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<ProductPart> ProductParts { get; set; } = new List<ProductPart>();
}
