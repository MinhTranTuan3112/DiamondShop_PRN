using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Promotion;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.BusinessLogic.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PromotionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Promotion>> GetPromotions(int pageIndex, int pageSize, string searchString, DateTime ExpireDate)
        {
            if (pageIndex == 0) pageIndex = 1;
            if (pageSize == 0) pageSize = 10;
            var promotions = await _unitOfWork.GetPromotionRepository().GetAllAsync();
            if (!searchString.IsNullOrEmpty())
            {
                promotions = promotions.Where(x => x.Name.ToLower().Contains(searchString.ToLower()) || (int.TryParse(searchString, out int discountPercent) && x.DiscountPercent == discountPercent)).ToList();
            }
            if(ExpireDate != default)
            {
                promotions = promotions.Where(x => x.ExpiredDate.Date == ExpireDate.Date).ToList();
            }
            return promotions.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<Promotion> GetPromotionById(Guid id)
        {
            var promotion = await _unitOfWork.GetPromotionRepository().GetByIdAsync(id);
            if (promotion == null)
            {
                throw new NotFoundException("Promotion not found");
            }
            return promotion;
        }

        public async Task CreatePromotion(CreatePromotion createPromotion)
        {
            Promotion p = createPromotion.Adapt<Promotion>();
            _unitOfWork.GetPromotionRepository().AddAsync(p);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePromotion(UpdatePromotion updatePromotion)
        {
            var promotion = await _unitOfWork.GetPromotionRepository().GetByIdAsync(updatePromotion.Id);
            if (promotion == null)
            {
                throw new NotFoundException("Promotion not found");
            }
            updatePromotion.Adapt(promotion);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePromotion(Guid id)
        {
            var promotion = await _unitOfWork.GetPromotionRepository().GetByIdAsync(id);
            if (promotion == null)
            {
                throw new NotFoundException("Promotion not found");
            }
            _unitOfWork.GetPromotionRepository().DeleteAsync(promotion);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
