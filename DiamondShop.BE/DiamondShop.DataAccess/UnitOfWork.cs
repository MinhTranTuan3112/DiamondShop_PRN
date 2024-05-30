using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Repositories;

namespace DiamondShop.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlashyCarbonDbContext _context;
        private readonly Lazy<IAccountRepository> _accountRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IPictureRepository> _pictureRepository;
        private readonly Lazy<IProductPartRepository> _productPartRepository;
        public UnitOfWork(FlashyCarbonDbContext context)
        {
            _context = context;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));
            _pictureRepository = new Lazy<IPictureRepository>(() => new PictureRepository(context));
            _productPartRepository = new Lazy<IProductPartRepository>(() => new ProductPartRepository(context));
        }

        public IAccountRepository GetAccountRepository()
        {
            return _accountRepository.Value;
        }

        public IPictureRepository GetPictureRepository()
        {
            return _pictureRepository.Value;
        }

        public IProductPartRepository GetProductPartRepository()
        {
            return _productPartRepository.Value;
        }

        public IProductRepository GetProductRepository()
        {
            return _productRepository.Value;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}