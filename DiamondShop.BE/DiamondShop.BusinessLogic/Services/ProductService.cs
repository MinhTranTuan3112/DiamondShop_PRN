using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;

namespace DiamondShop.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        
        public async Task<PagedResult<GetProductWithCategoryDto>> GetPagedProducts(QueryDto queryDto)
        {
            throw new NotImplementedException();
        }
    }
}