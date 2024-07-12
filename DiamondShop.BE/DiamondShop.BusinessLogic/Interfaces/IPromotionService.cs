using DiamondShop.DataAccess.DTOs.Promotion;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IPromotionService
    {
        Task<List<Promotion>> GetPromotions(int pageIndex, int pageSize, string searchString);
        Task CreatePromotion(CreatePromotion createPromotion);
        Task UpdatePromotion(UpdatePromotion updatePromotion);
        Task DeletePromotion(Guid id);
    }
}
