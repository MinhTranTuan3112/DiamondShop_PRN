using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Order;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task AddToCart(AddToCartDto addToCartDto, ClaimsPrincipal claims);
        public Task<bool> ChangeStaffOrStatus(StaffReceiveDto ord, string staffRole);
        public Task<bool> ChangeInfoOrStatus(CustomerSendDto ord);
        public Task<bool> DeleteOrder(Guid orderId);
    }
}