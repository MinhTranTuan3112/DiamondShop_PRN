using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> GetOrderById(Guid id, bool includeDetail);
        Task AddToCart(AddToCartDto addToCartDto, ClaimsPrincipal claims);
        public Task<bool> UpdateStatus(Guid ordId, string newStatus, string interacterRole);
        public Task<bool> UpdateOrder(OrderInfoDto order);
        public Task<bool> DeleteOrder(Guid orderId);
    }
}