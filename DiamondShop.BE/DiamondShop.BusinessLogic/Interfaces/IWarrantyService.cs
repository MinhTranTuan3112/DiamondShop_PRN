
using DiamondShop.DataAccess.DTOs.Warranty;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IWarrantyService
    {
        public Task<Warranty> GetDetailAsync(Guid id);
        public Task<IEnumerable<Warranty>> GetWarranties_Of_OrderDetail(Guid orderDetailId);
        //public Task<IEnumerable<Warranty>> ViewListOfWarranty(WarrantyFilterDto filtered);
        public Task<bool> CreateWarranty(WarrantyNewDto warrantyNew);
    }
}
