using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class Diamond
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Color { get; set; }

    public string? Origin { get; set; }

    public string? CaratWeight { get; set; }

    public string? Clarity { get; set; }

    public string? Cut { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public virtual ICollection<DiamondProduct> DiamondProducts { get; set; } = new List<DiamondProduct>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();
}
