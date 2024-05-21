using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class DiamondProduct
{
    public Guid Id { get; set; }

    public bool? IsMain { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? DiamondId { get; set; }

    public virtual Diamond? Diamond { get; set; }

    public virtual Product? Product { get; set; }
}
