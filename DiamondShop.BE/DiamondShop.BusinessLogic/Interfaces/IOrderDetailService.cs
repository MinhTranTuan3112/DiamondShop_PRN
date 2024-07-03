using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.DTOs.OrderDetail;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IOrderDetailService
    {
        Task HandleAddProductToCart(Order order, AddToCartDto addToCartDto);
        Task HandleAddDiamondToCart(Order order, AddToCartDto addToCartDto);
        public Task<OrderDetail> Get_OrderDetail_By_Id(Guid orderDetailId);
        public Task<IEnumerable<OrderDetail>> GetList_OrderDetail_By_OrderId(Guid orderId);
        public Task<IEnumerable<OrderDetail>> GetList_OrderDetail_By_Filter(OrderDetail_InfoDto filters);
    }
}