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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly FlashyCarbonDbContext _context;

        public CategoryRepository(FlashyCarbonDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.Where(c => c.Status == "available").ToListAsync();
        }
    }
}
