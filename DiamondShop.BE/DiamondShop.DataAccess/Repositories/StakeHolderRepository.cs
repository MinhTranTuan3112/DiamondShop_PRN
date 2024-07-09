using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Repositories;

public class StakeHolderRepository: GenericRepository<StakeHolder>, IStakeHolderRepository
{
    public StakeHolderRepository(FlashyCarbonDbContext context) : base(context)
    {
    }
}