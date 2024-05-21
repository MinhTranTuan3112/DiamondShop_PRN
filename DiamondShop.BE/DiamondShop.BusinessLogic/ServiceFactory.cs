using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.BusinessLogic.Services;
using DiamondShop.DataAccess.Interfaces;

namespace DiamondShop.BusinessLogic
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly Lazy<IAuthService> _authService;

        public ServiceFactory()
        {
            _authService = new Lazy<IAuthService>(() => new AuthService());
        }

        public IAuthService GetAuthService()
        {
            return _authService.Value;
        }
    }
}