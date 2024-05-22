using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class Account
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? AvatarUrl { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string Role { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<StakeHolder> StakeHolders { get; set; } = new List<StakeHolder>();
}
