﻿using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class Customer
{
    public Guid Id { get; set; }

    public string? Fullname { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public int? Point { get; set; }

    public Guid? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}