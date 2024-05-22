using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.DataAccess.Repositories;

namespace DiamondShop.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlashyCarbonDbContext _context;
        private readonly Lazy<IAccountRepository> _accountRepository;

        public UnitOfWork(FlashyCarbonDbContext context)
        {
            _context = context;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
        }

        public IAccountRepository GetAccountRepository()
        {
            return _accountRepository.Value;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}