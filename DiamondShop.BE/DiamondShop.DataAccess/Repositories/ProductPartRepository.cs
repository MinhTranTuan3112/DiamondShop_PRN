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
    public class ProductPartRepository : GenericRepository<ProductPart>, IProductPartRepository
    {
        private readonly FlashyCarbonDbContext _dbContext;

        public ProductPartRepository(FlashyCarbonDbContext context) : base(context)
        {
            this._dbContext = context;
        }

        public async Task<IEnumerable<ProductPart>> GetProductPartByProductId(Guid productId)
        {
            return await _dbContext.ProductParts.Include("Diamond").Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}
