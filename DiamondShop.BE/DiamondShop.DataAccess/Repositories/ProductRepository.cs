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
    public class ProductRepository : GenericRepository<Product>, IProductRepository

    {
        private readonly FlashyCarbonDbContext _dbContext;

        public ProductRepository(FlashyCarbonDbContext context) : base(context)
        {
            this._dbContext = context;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _dbContext.Products.Include("Category").FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
               return null!;
            }
            return product;
        }
    }
}
