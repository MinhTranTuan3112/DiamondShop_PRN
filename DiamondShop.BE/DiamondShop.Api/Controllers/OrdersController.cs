using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public OrdersController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost("add-to-cart"), Authorize(Roles = "Customer, customer")]
        public async Task<ActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            await _serviceFactory.GetOrderService().AddToCart(addToCartDto, HttpContext.User);
            return Ok();
        }

        [HttpPost("{orderId:guid}")]
        [Authorize(Roles = "Customer, customer")]
        public async Task<ActionResult> ConfirmOrder(Guid orderId)
        {
            await _serviceFactory.GetOrderService().ConfirmOrder(orderId, HttpContext.User);
            return Ok();
        }

    }
}