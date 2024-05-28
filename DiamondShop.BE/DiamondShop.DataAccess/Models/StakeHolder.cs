using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class StakeHolder
{
    public Guid Id { get; set; }

    public string? Fullname { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? DateHired { get; set; }

    public Guid AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Order> OrderDeliveryStaffs { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderSalesStaffs { get; set; } = new List<Order>();
}
