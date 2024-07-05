using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly FlashyCarbonDbContext _context;
        public AccountRepository(FlashyCarbonDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Account?> GetAccountDetail(Guid id)
        {
            return await _context.Accounts.Include(x => x.Customer)
                                          .Include(x => x.StakeHolder)
                                          .SingleOrDefaultAsync(x => x.Id == id);
        }
        
    }
}