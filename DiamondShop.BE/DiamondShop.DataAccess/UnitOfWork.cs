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

        public UnitOfWork(FlashyCarbonDbContext context)
        {
            _context = context;
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(context));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
            _orderDetailRepository = new Lazy<IOrderDetailRepository>(() => new OrderDetailRepository(context));
        }

        public IAccountRepository GetAccountRepository()
        {
            return _accountRepository.Value;
        }

        public ICustomerRepository GetCustomerRepository()
        {
            return _customerRepository.Value;
        }

        public IOrderDetailRepository GetOrderDetailRepository()
        {
            return _orderDetailRepository.Value;
        }

        public IOrderRepository GetOrderRepository()
        {
            return _orderRepository.Value;
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