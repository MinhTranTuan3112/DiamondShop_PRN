using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> GetOrderById(Guid id);
        Task<List<Order>> GetOrdersByStatus(ClaimsPrincipal claims, OrderStatus status);
        public Task<PagedResult<Order>?> GetList(QueryOrderDto query);
        Task AddToCart(AddToCartDto addToCartDto, ClaimsPrincipal claims);
        public Task<bool> UpdateStatus(Guid ordId, string newStatus, string interacterRole);
        public Task<bool> UpdateOrder(OrderInfoDto order);
        public Task<bool> DeleteOrder(Guid orderId);
        Task<OrderStatistic> GetOrderStatisticsAsync(int month);
        Task<DashboardStats> getDashBoardStats();
    }
}