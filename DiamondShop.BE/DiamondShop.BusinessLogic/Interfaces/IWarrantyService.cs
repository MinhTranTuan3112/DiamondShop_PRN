using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.DTOs.Warranty;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using System.Text.RegularExpressions;
using System.Text;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IWarrantyService
    {
        public Task<Warranty> GetDetailAsync(Guid id);
        public Task<IEnumerable<Warranty>> GetWarranties_Of_OrderDetailAsync(Guid orderDetailId);
        public Task<PagedResult<Warranty>> GetFiltered_List_WarrantyAsync(WarrantyFilterDto filtered);
        public Task<bool> CreateWarrantyAsync(WarrantyNewDto warrantyNew);
        public Task<bool> UpdateWarrantyAsync(WarrantyUpdateDto warranty_input);
        public Task<bool> ChangeStatus(Guid warrantyId, WarrantyStatus enumStatus);
        public Task<bool> DeleteWarrantyAsync(Guid id);
    }
}
