using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class Category
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public DateTime? LastUpdate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
