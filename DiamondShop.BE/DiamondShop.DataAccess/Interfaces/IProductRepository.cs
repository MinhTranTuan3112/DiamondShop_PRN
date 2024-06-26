using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetProductDetailById(Guid id);
        Task<PagedResult<Product>> GetPagedProducts(QueryProductDto queryProductDto);

        Task<Product?> GetProductWithCategoryById(Guid id);
    }
}
