using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.BusinessLogic.Services;
using DiamondShop.DataAccess.Interfaces;
using FluentEmail.Core;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client.Extensions.Msal;
using Razor.Templating.Core;

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
        private readonly Lazy<IFirebaseStorageService> _firebaseStorageService;
        private readonly Lazy<IPictureService> _pictureService;
        private readonly Lazy<IProductPartService> _productPartService;
        private readonly Lazy<IAccountService> _accountService;
        private readonly Lazy<ICertificateService> _certificateSerivce;
        private readonly Lazy<IPromotionService> promotionService;

        private readonly Lazy<IEmailService> _emailService;
        public ServiceFactory(IUnitOfWork unitOfWork, IConfiguration configuration, StorageClient storageClient,
        IFluentEmailFactory fluentEmailFactory, IRazorTemplateEngine razorTemplateEngine)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService(unitOfWork, configuration));
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork, this));
            _orderService = new Lazy<IOrderService>(() => new OrderService(unitOfWork, this));
            _diamondService = new Lazy<IDiamondService>(() => new DiamondService(unitOfWork, this));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(unitOfWork));
            _orderDetailService = new Lazy<IOrderDetailService>(() => new OrderDetailService(unitOfWork));
            _warrantyService = new Lazy<IWarrantyService>(() => new WarrantyService(unitOfWork));
            _firebaseStorageService = new Lazy<IFirebaseStorageService>(() => new FirebaseStorageService(storageClient, configuration));
            _pictureService = new Lazy<IPictureService>(() => new PictureService(unitOfWork, this));
            _productPartService = new Lazy<IProductPartService>(() => new ProductPartService(unitOfWork));
            _accountService = new Lazy<IAccountService>(() => new AccountService(unitOfWork, this));
            _certificateSerivce = new Lazy<ICertificateService>(() => new CertificateService(unitOfWork));
            promotionService = new Lazy<IPromotionService>(() => new PromotionService(unitOfWork));
            _emailService = new Lazy<IEmailService>(() => new EmailService(fluentEmailFactory, razorTemplateEngine));
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

        public IFirebaseStorageService GetFirebaseStorageService()
        {
            return _firebaseStorageService.Value;
        }

        public IProductPartService GetProductPartService()
        {
            return _productPartService.Value;
        }

        public IOrderDetailService GetOrderDetailService()
        {
            return _orderDetailService.Value;
        }

        public IOrderService GetOrderService()
        {
            return _orderService.Value;
        }

        public IPictureService GetPictureService()
        {
            return _pictureService.Value;
        }

        public IAccountService GetAccountService()
        {
            return _accountService.Value;
        }

        public ICertificateService GetCertificateService()
        {
            return _certificateSerivce.Value;
        }

        public IProductService GetProductService()
        {
            return _productService.Value;
        }
        public IWarrantyService GetWarrantyService()
        {
            return _warrantyService.Value;
        }
        public IPromotionService GetPromotionService()
        {
            return promotionService.Value;
        }

        public IEmailService GetEmailService()
        {
            return _emailService.Value;
        }
    }
}