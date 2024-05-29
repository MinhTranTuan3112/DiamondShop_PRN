using DiamondShop.DataAccess.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<ViewProductDTO>> GetProductAsync(Guid id);
    }
}
