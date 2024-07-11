using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.DTOs.Warranty;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Interfaces
{
    public interface IWarrantyRepository : IGenericRepository<Warranty>
    {
        public Task<Warranty?> GetWarranty_Include_OrderDetail_Product(Guid warrantyId);
        public Task<PagedResult<Warranty>?> GetFilteredListAsync(WarrantyFilterDto input);
    }
}
