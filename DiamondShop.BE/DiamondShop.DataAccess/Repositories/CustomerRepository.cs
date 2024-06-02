using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly FlashyCarbonDbContext _context;
        public CustomerRepository(FlashyCarbonDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer?> GetCustomerWithOrdersInfo(Guid accountId)
        {
            var customer = await _context.Customers.Include(c => c.Account)
                                              .SingleOrDefaultAsync(c => c.AccountId == accountId);
            return customer;
        }
    }
}