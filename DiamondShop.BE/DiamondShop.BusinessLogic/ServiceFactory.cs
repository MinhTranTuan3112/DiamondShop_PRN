using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.BusinessLogic.Services;
using DiamondShop.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DiamondShop.BusinessLogic
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<IDiamondService> _diamondService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IOrderDetailService> _orderDetailService;
        private readonly Lazy<IWarrantyService> _warrantyService;
        public ServiceFactory(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService(unitOfWork, configuration));
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork));
            _orderService = new Lazy<IOrderService>(() => new OrderService(unitOfWork, this));
            _diamondService = new Lazy<IDiamondService>(() => new DiamondService(unitOfWork));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(unitOfWork));
            _orderDetailService = new Lazy<IOrderDetailService>(() => new OrderDetailService(unitOfWork));
            _warrantyService = new Lazy<IWarrantyService>(() => new WarrantyService(unitOfWork));
        }

        public IAuthService GetAuthService()
        {
            return _authService.Value;
        }

        public ICategoryService GetCategoryService()
        {
            return _categoryService.Value;
        }

        public IDiamondService GetDiamondService()
        {
            return _diamondService.Value;
        }

        public IOrderDetailService GetOrderDetailService()
        {
            return _orderDetailService.Value;
        }

        public IOrderService GetOrderService()
        {
            return _orderService.Value;
        }

        public IProductService GetProductService()
        {
            return _productService.Value;
        }
        public IWarrantyService GetWarrantyService()
        {
            return _warrantyService.Value;
        }
    }
}