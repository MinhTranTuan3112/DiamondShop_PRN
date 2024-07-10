using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class ProductPart
{
    public Guid Id { get; set; }

    public bool IsMain { get; set; }

    public int Point { get; set; }

    public Guid ProductId { get; set; }

    public Guid DiamondId { get; set; }

    public virtual Diamond Diamond { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
