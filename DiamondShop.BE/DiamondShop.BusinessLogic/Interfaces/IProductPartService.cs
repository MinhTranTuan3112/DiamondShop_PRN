using DiamondShop.DataAccess.DTOs.ProductPart;

namespace DiamondShop.BusinessLogic.Interfaces;

public interface IProductPartService
{
    Task CreateProductPart(List<CreateProductPartDto> createProductPartDtos, Guid diamondId);
}