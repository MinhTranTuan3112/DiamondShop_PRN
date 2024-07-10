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
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IOrderDetailRepository> _orderDetailRepository;
        private readonly Lazy<IDiamondRepository> _diamondRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IProductPartRepository> _productPartRepository;
        private readonly Lazy<IPictureRepository> _pictureRepository;
        private readonly Lazy<IStakeHolderRepository> _stakeHolderRepository;
        private readonly Lazy<ICertificateRepository> _certificateRepository;
        public UnitOfWork(FlashyCarbonDbContext context)
        {
            _context = context;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(context));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
            _orderDetailRepository = new Lazy<IOrderDetailRepository>(() => new OrderDetailRepository(context));
            _diamondRepository = new Lazy<IDiamondRepository>(() => new DiamondRepository(context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
            _productPartRepository = new Lazy<IProductPartRepository>(() => new ProductPartRepository(context));
            _pictureRepository = new Lazy<IPictureRepository>(() => new PictureRepository(context));
            _stakeHolderRepository = new Lazy<IStakeHolderRepository>(() => new StakeHolderRepository(context));
            _certificateRepository = new Lazy<ICertificateRepository>(() => new CertificateRepository(context));
        }

        public IAccountRepository GetAccountRepository()
        {
            return _accountRepository.Value;
        }

        public ICategoryRepository GetCategoryRepository()
        {
            return _categoryRepository.Value;
        }

        public ICustomerRepository GetCustomerRepository()
        {
            return _customerRepository.Value;
        }

        public IDiamondRepository GetDiamondRepository()
        {
            return  _diamondRepository.Value;
        }

        public IOrderDetailRepository GetOrderDetailRepository()
        {
            return _orderDetailRepository.Value;
        }

        public IOrderRepository GetOrderRepository()
        {
            return _orderRepository.Value;
        }

        public IPictureRepository GetPictureRepository()
        {
            return _pictureRepository.Value;
        }

        public IStakeHolderRepository GetStakeHolderRepository()
        {
            return _stakeHolderRepository.Value;
        }

        public ICertificateRepository GetCertificateRepository()
        {
            return _certificateRepository.Value;
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