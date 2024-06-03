using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Diamond
{
    public class GetDiamondIdDto
    {
        public required Guid Id { get; set; }
    }
}