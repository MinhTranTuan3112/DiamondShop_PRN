using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        Task<GetProductDetailDto> GetProductDetailById(Guid id);
        Task<PagedResult<GetProductInPagedResultDto>> GetPagedProducts(QueryProductDto queryProductDto);
    }
}
        
    

