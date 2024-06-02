using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.Interfaces
{
    public interface IDiamondRepository : IGenericRepository<Diamond>
    {
        Task<PagedResult<Diamond>> GetPagedDiamonds(QueryDiamondDto queryDiamondDto);
    }
}
