using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IOrderDetailService
    {
        Task HandleAddProductToCart(Order order, AddToCartDto addToCartDto);
        Task HandleAddDiamondToCart(Order order, AddToCartDto addToCartDto);
    }
}