using DiamondShop.DataAccess.DTOs.Promotion;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IPromotionService
    {
        Task<(List<Promotion> Promotions, int TotalPage)> GetPromotions(int pageIndex, int pageSize, string searchString, DateTime ExpireDate);
        Task<Promotion> GetPromotionById(Guid id);
        Task CreatePromotion(CreatePromotion createPromotion);
        Task UpdatePromotion(UpdatePromotion updatePromotion);
        Task DeletePromotion(Guid id);
    }
}
