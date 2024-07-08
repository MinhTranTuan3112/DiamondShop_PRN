using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.BusinessLogic.Services;
using DiamondShop.DataAccess.DTOs.Category;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.OrderDetail;
using DiamondShop.DataAccess.Models;
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
            TypeAdapterConfig<UpdateDiamondDto, Diamond>.NewConfig().IgnoreNullValues(true);
            TypeAdapterConfig<UpdateCategoryDto, Category>.NewConfig().IgnoreNullValues(true);
            TypeAdapterConfig<OrderDetail_InfoDto, OrderDetail>.NewConfig().IgnoreNullValues(true)
                .Map(destination => destination.Id, startFrom => startFrom.OrderDetailId);
            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}