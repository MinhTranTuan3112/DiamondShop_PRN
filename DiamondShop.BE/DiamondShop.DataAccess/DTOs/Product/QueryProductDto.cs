using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Query;

namespace DiamondShop.DataAccess.DTOs.Product
{
    public record QueryProductDto(
        QueryDto QueryDto,
        decimal StartPrice,
        decimal EndPrice,
        List<Guid> CategoryIds,
        string? Material,
        List<Guid> DiamondIds
    );
}