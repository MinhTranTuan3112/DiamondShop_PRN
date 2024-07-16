using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.DTOs.OrderDetail;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IOrderDetailService
    {
        Task HandleAddProductToCart(Order order, AddToCartDto addToCartDto);
        Task HandleAddDiamondToCart(Order order, AddToCartDto addToCartDto);
        public Task<OrderDetail> Get_OrderDetail_By_Id(Guid orderDetailId);
        public Task<OrderDetail> Get_OrderDetail_IncludeReference(Guid orderDetailId);
        public Task<IEnumerable<OrderDetail>> GetList_OrderDetail_By_OrderId(Guid orderId);
        public Task<IEnumerable<OrderDetail>> GetList_OrderDetail_By_Filter(OrderDetail_PagingDto filters);
        public Task<bool> UpdateOrderDetail(OrderDetail_InfoDto updatedOrderDetail);
        public Task<bool> DeleteOrderDetail(Guid orderDetailId);

    }
}