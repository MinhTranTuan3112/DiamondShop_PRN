using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        Task<GetProductDetailDto> GetProductDetailById(Guid id);
        Task<PagedResult<GetProductInPagedResultDto>> GetPagedProducts(QueryProductDto queryProductDto);
        Task<GetProductIdDto> CreateProduct(CreateProductDto createProductDto);

        Task<GetProductIdDto> CreateProductProperties(Guid productId, CreateProductPropetiesDto createProductPropertiesDto);

        Task UpdateProduct(Guid productId, UpdateProductDto updateProductDto);
        Task UpdateProductProperties(Guid productId, CreateProductPropetiesDto createProductPropertiesDto);

        Task DeleteProduct(Guid productId, ProductStatus status);
    }
}
        
    

