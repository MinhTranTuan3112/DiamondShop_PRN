using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.ProductPart;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Mapster;

namespace DiamondShop.BusinessLogic.Services;

public class ProductPartService : IProductPartService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductPartService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task CreateProductPart(List<CreateProductPartDto> createProductPartDtos, Guid productId)
    {
        var productParts = createProductPartDtos.Select(p =>
        {
            var productPart = p.Adapt<ProductPart>();
            productPart.ProductId = productId;
            return productPart;
        });
        await _unitOfWork.GetProductPartRepository().AddRangeAsync(productParts);
        await _unitOfWork.SaveChangesAsync();
    }
}