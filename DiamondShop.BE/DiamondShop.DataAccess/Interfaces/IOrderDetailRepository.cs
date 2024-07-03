using DiamondShop.DataAccess.DTOs.OrderDetail;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Interfaces
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        public Task<IEnumerable<OrderDetail>> GetListOrderDetailByFilter(OrderDetail_InfoDto filters);
    }
}