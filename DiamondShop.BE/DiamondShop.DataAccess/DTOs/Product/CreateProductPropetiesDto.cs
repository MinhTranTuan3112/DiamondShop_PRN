using DiamondShop.DataAccess.DTOs.ProductPart;

namespace DiamondShop.DataAccess.DTOs.Product;

public class CreateProductPropetiesDto
{
    public List<CreateProductPartDto> CreateProductPartDtos { get; set; } = [];
}