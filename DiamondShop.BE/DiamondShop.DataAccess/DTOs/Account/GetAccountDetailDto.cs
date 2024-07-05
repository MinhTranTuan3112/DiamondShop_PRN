using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Customer;
using DiamondShop.DataAccess.DTOs.StakeHolder;

namespace DiamondShop.DataAccess.DTOs.Account
{
    public class GetAccountDetailDto
    {
        public Guid Id { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? AvatarUrl { get; set; }

        public DateTime? TimeStamp { get; set; }

        public string Role { get; set; } = null!;

        public string? Status { get; set; }
        public GetCustomerDto? Customer { get; set; }
        public GetStakeHolderDto? StakeHolder { get; set; }
    }
}