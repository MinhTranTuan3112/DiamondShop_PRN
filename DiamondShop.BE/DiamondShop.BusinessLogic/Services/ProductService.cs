using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Picture;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.ProductPart;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Mapster;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Query;
namespace DiamondShop.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetProductDetailDto> GetProductAsync(Guid id)
        {
        
            var product = await _unitOfWork.GetProductRepository().GetProductById(id);
            if (product == null)
            {
               throw new NotFoundException("Products are empty");
            }
            var productDetail = product.Adapt<GetProductDetailDto>();
            productDetail.Pictures = new List<GetPictureDto>();
            productDetail.ProductParts = new List<ProductPartDTO>();

            Expression<Func<Picture, bool>> expression = p => p.ProductId == id;
            var pictures = await _unitOfWork.GetPictureRepository().FindAsync(expression);
            var productParts = await _unitOfWork.GetProductPartRepository().GetProductPartByProductId(id);
            if (pictures is null)
                pictures = new List<Picture>();
            if (productParts is null)
                productParts = new List<ProductPart>();
            foreach (var picture in pictures)
            {
                productDetail.Pictures.Add(picture.Adapt<GetPictureDto>());
            }
            foreach (var part in productParts)
            {
                productDetail.ProductParts.Add(part.Adapt<ProductPartDTO>());
            }
            return productDetail;
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

