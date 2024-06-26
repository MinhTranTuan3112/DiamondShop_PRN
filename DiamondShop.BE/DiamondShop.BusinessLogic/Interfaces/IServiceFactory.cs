using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IServiceFactory
    {
        IAuthService GetAuthService();

        IProductService GetProductService();

        IOrderService GetOrderService();

        IDiamondService GetDiamondService();

        ICategoryService GetCategoryService();

        IOrderDetailService GetOrderDetailService();

        IFirebaseStorageService GetFirebaseStorageService();
        IProductPartService GetProductPartService();

        IPictureService GetPictureService();
    }
}