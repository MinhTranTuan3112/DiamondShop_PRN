using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Repositories;

public class PictureRepository : GenericRepository<Picture>, IPictureRepository
{
    private readonly FlashyCarbonDbContext _context;

    public PictureRepository(FlashyCarbonDbContext context) : base(context)
    {
        this._context = context;
    }
}