using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository GetAccountRepository();
        Task<int> SaveChangesAsync();
    }
}