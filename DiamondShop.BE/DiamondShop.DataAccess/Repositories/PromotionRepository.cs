using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
    {
        private readonly FlashyCarbonDbContext _context;
        public PromotionRepository(FlashyCarbonDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Promotion?> GetByCode(string code)
        {
            var promotion =  await _context.Promotions.FirstOrDefaultAsync(p => p.Name.Equals(code));

            if (promotion == null) { 
                return null;
            }
            return promotion;
        }
    }
}
