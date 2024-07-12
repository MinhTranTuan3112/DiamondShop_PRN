using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.BusinessLogic.Services;
using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.DTOs.Category;
using DiamondShop.DataAccess.DTOs.Certificate;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.OrderDetail;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.ProductPart;
using DiamondShop.DataAccess.Models;
using Google.Cloud.Storage.V1;
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
            TypeAdapterConfig<UpdateProductDto, Product>.NewConfig().IgnoreNullValues(true);
            TypeAdapterConfig<CreateProductPartDto, ProductPart>.NewConfig().IgnoreNullValues(true);
            TypeAdapterConfig<UpdateAccountDto, Account>.NewConfig().IgnoreNullValues(true);
            TypeAdapterConfig<UpdateCertificateDto, Certificate>.NewConfig().IgnoreNullValues(true);
            TypeAdapterConfig<UpdateCertificateDto, Diamond>.NewConfig().IgnoreNullValues(true);
            TypeAdapterConfig<UpdateDiamondDto, Certificate>.NewConfig().IgnoreNullValues(true);
            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddSingleton(opt => StorageClient.Create());
            services.AddScoped<IFirebaseStorageService, FirebaseStorageService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}