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
        Task ConfirmOrder(Guid orderId, ClaimsPrincipal claims);
    }
}