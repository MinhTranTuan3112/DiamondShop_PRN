using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository GetAccountRepository();
        IProductRepository GetProductRepository();
        IOrderRepository GetOrderRepository();
        ICustomerRepository GetCustomerRepository();
        IOrderDetailRepository GetOrderDetailRepository();
        IDiamondRepository GetDiamondRepository(); 
        ICategoryRepository GetCategoryRepository();
        IProductPartRepository GetProductPartRepository();
        IPictureRepository GetPictureRepository();
        Task<int> SaveChangesAsync();
    }
}