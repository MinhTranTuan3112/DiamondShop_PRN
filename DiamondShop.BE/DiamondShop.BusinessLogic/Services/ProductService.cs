﻿using System.ComponentModel.DataAnnotations;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.Shared.Exceptions;
using Mapster;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Models;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceFactory _serviceFactory;
        public ProductService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory)
        {
            _unitOfWork = unitOfWork;
            _serviceFactory = serviceFactory;
        }
        public async Task<GetProductIdDto> CreateProduct(CreateProductDto createProductDto)
        {
            var categoryExists = await _unitOfWork.GetCategoryRepository().AnyAsync(c => c.Id == createProductDto.CategoryId);
            if (!categoryExists)
            {
                throw new NotFoundException("Can't find any category with this id");
            }
            var product = createProductDto.Adapt<Product>();
            product.Status = CategoryStatus.Available.ToString();
            product.LastUpdate = DateTime.Now;
            await _unitOfWork.GetProductRepository().AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            if (createProductDto.ProductPicture is not [])
            {
                await _serviceFactory.GetPictureService().UploadProductPictures(createProductDto.ProductPicture, product.Id);
            }
            return new GetProductIdDto { Id = product.Id };
        }

        public async Task<GetProductIdDto> CreateProductProperties(Guid productId, CreateProductPropetiesDto createProductPropertiesDto)
        {
            var product = await _unitOfWork.GetProductRepository().GetByIdAsync(productId);
            if (product is null)
            {
                throw new NotFoundException("Product is not existed");
            }
            var inputDiamondIds = createProductPropertiesDto.CreateProductPartDtos.Select(p => p.DiamondId);
            var validDiamondCount = await _unitOfWork.GetDiamondRepository().CountAsync(d => inputDiamondIds.Contains(d.Id));
            if (validDiamondCount != inputDiamondIds.Count())
            {
                throw new NotFoundException("One or more Diamonds are invalid.");
            }

            await _serviceFactory.GetProductPartService()
                .CreateProductPart(createProductPropertiesDto.CreateProductPartDtos, product.Id);
            return new GetProductIdDto { Id = productId };
        }

        public async Task UpdateProduct(Guid productId, UpdateProductDto updateProductDto)
        {
            var product = await _unitOfWork.GetProductRepository().GetProductDetailById(productId);
            if (product is null)
            {
                throw new NotFoundException("Product is not existed");
            }

            updateProductDto.Adapt(product);
            product.LastUpdate = DateTime.Now;
            if (product.Pictures.Any())
            {
                await _serviceFactory.GetPictureService().DeletePictures(product.Pictures);
                product.Pictures.Clear();
            }

            await _unitOfWork.SaveChangesAsync();
            if (updateProductDto.ProductPicture is not [])
            {
                await _serviceFactory.GetPictureService()
                    .UploadProductPictures(updateProductDto.ProductPicture, product.Id);
            }
        }

        public async Task UpdateProductProperties(Guid productId, CreateProductPropetiesDto createProductPropertiesDto)
        {
            var product = await _unitOfWork.GetProductRepository().GetByIdAsync(productId);
            if (product is null)
            {
                throw new NotFoundException("Product is not existed");
            }
            var inputDiamondIds = createProductPropertiesDto.CreateProductPartDtos.Select(p => p.DiamondId);
            var validDiamondCount = await _unitOfWork.GetDiamondRepository().CountAsync(d => inputDiamondIds.Contains(d.Id));
            if (validDiamondCount != inputDiamondIds.Count())
            {
                throw new NotFoundException("One or more Diamonds are invalid.");
            }

            if (product.ProductParts.Any())
            {
                await _unitOfWork.GetProductPartRepository().DeleteRangeAsync(product.ProductParts);
                product.ProductParts.Clear();
            }

            await _unitOfWork.SaveChangesAsync();
            await _serviceFactory.GetProductPartService()
                .CreateProductPart(createProductPropertiesDto.CreateProductPartDtos, product.Id);
        }

        public async Task DeleteProduct(Guid productId, ProductStatus status)
        {
            var product = await _unitOfWork.GetProductRepository().GetByIdAsync(productId);
            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }

            product.Status = status switch
            {
                ProductStatus.Available => ProductStatus.Available.ToString().ToLower(),
                ProductStatus.OutOfStock => ProductStatus.OutOfStock.ToString().ToLower(),
                ProductStatus.Deleted => ProductStatus.Deleted.ToString().ToLower(),
                _ => product.Status
            };

            product.LastUpdate = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<GetProductDetailDto> GetProductDetailById(Guid id)
        {
        
            var product = await _unitOfWork.GetProductRepository().GetProductDetailById(id);
            if (product is null)
            {
               throw new NotFoundException("Product not found");
            }
            return product.Adapt<GetProductDetailDto>();
        }
    


        public async Task<PagedResult<GetProductInPagedResultDto>> GetPagedProducts(QueryProductDto queryProductDto)
        {
            if (queryProductDto.StartPrice > queryProductDto.EndPrice)
            {
                throw new BadRequestException("Start price must be less than end price");
            }

            return (await _unitOfWork.GetProductRepository().GetPagedProducts(queryProductDto)).Adapt<PagedResult<GetProductInPagedResultDto>>();
        }

        public List<string> GetProductTypes()
        {
            return [.. Enum.GetNames(typeof(ProductType))];
        }
    }
}    

