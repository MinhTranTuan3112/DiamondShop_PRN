using System;
using System.Collections.Generic;

namespace DiamondShop.DataAccess.Models;

public partial class Account
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string Role { get; set; } = null!;

    public string? Status { get; set; } 

    public virtual Customer? Customer { get; set; }

    public virtual StakeHolder? StakeHolder { get; set; }
}
