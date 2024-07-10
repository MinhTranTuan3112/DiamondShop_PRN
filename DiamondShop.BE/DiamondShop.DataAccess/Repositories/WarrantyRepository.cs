using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Repositories
{
    public class WarrantyRepository : GenericRepository<Warranty> ,IWarrantyRepository
    {
        public WarrantyRepository(FlashyCarbonDbContext context) : base(context)
        {
        }
    }
}
