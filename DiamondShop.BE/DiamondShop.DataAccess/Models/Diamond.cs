using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class Diamond
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Color { get; set; }

    public string? Origin { get; set; }

    public string? CertificationUrl { get; set; }

    public string? CaratWeight { get; set; }

    public string? Clarity { get; set; }

    public string? Cut { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int WarrantyPeriod { get; set; }

    public DateTime? LastUpdate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<ProductPart> ProductParts { get; set; } = new List<ProductPart>();
}
