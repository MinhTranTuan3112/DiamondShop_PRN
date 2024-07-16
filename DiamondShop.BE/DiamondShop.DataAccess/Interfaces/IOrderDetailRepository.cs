using DiamondShop.DataAccess.DTOs.OrderDetail;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Interfaces
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        public Task<OrderDetail?> GetById_IncludeReference(Guid orderDetailId);
        public Task<PagedResult<OrderDetail>> GetListOrderDetailByFilter(OrderDetail_PagingDto filters);
        public Task<bool> DeleteOrderDetailAndReferences(OrderDetail? orderDetail);
        Task<IEnumerable<OrderDetail>> GetListOrderDetailfromOrderId(Guid orderid);
    }
}