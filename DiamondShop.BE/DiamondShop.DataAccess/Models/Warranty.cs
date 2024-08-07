﻿namespace DiamondShop.DataAccess.Models;

public partial class Warranty
{
    public Guid Id { get; set; }

    public string ItemName { get; set; } = null!;

    public bool? IsProduct { get; set; }

    public string? Type { get; set; }

    public string? Privacy { get; set; }

    public string? Condition { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Reason { get; set; }

    public string Status { get; set; } = null!;

    public Guid OrderDetailId { get; set; }

    public virtual OrderDetail OrderDetail { get; set; } = null!;
}
