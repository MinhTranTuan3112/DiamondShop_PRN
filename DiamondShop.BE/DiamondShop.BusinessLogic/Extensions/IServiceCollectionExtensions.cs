using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.BusinessLogic.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DiamondShop.BusinessLogic.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddServices()
                    .AddMapsterConfigurations();
            return services;
        }

        private static IServiceCollection AddMapsterConfigurations(this IServiceCollection services)
        {
            services.AddMapster();
            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}