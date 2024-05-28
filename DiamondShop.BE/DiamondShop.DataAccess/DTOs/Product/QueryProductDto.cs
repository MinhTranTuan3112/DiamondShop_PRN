using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Product
{
    public record struct QueryProductDto(
        decimal StartPrice,
        decimal EndPrice,
        List<Guid> CategoryIds
    );
}