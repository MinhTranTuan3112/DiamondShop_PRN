using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class Certification
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? UrlPath { get; set; }

    public Guid DiamondId { get; set; }

    public virtual Diamond Diamond { get; set; } = null!;
}
