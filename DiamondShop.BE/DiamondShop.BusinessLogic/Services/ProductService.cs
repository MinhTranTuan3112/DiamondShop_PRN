using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.Shared.Exceptions;
using Mapster;

namespace DiamondShop.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<GetProductInPagedResultDto>> GetPagedProducts(QueryProductDto queryProductDto)
        {
            if (queryProductDto.StartPrice > queryProductDto.EndPrice)
            {
                throw new BadRequestException("Start price must be less than end price");
            }

            return (await _unitOfWork.GetProductRepository().GetPagedProducts(queryProductDto)).Adapt<PagedResult<GetProductInPagedResultDto>>();
        }
    }
}