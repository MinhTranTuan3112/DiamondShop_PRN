using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(FlashyCarbonDbContext context) : base(context)
        {
        }
    }
}
