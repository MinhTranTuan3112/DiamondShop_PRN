using DiamondShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.Interfaces
{
    public interface IProductPartRepository : IGenericRepository<ProductPart>
    {
        Task<IEnumerable<ProductPart>> GetProductPartByProductId(Guid productId);
    }
}
