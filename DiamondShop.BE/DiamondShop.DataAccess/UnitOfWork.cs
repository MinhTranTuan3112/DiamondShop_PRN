using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Interfaces;

namespace DiamondShop.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlashyCarbonDbContext _context;

        public UnitOfWork(FlashyCarbonDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}