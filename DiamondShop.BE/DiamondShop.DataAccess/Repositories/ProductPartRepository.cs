using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.Repositories
{
    public class ProductPartRepository : GenericRepository<ProductPart>, IProductPartRepository
    {
        private readonly FlashyCarbonDbContext _context;

        public ProductPartRepository(FlashyCarbonDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
