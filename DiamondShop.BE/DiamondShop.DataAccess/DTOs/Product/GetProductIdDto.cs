using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Product
{
    public class GetProductIdDto
    {
        public required Guid Id { get; set; }
    }
}
