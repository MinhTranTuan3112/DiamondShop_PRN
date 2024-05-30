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
        public ServiceFactory(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService(unitOfWork, configuration));
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork));
        }

        public IAuthService GetAuthService()
        {
            return _authService.Value;
        }

        public IProductService GetProductService()
        {
            return _productService.Value;
        }
    }
}