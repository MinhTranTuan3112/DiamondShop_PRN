using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpPost("add-to-cart"), Authorize(Roles = "Customer")]
        public async Task<ActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            await _serviceFactory.GetOrderService().AddToCart(addToCartDto, HttpContext.User);
            return Ok();
        }

        [HttpPost("send-order"), Authorize(Roles = "Customer")]
        public async Task<IActionResult> SendOrder(CustomerSendDto order)
        {
            bool resultSuccess = await _serviceFactory.GetOrderService().ChangeInfoOrStatus(order);
            return resultSuccess ? Ok("Send Success") : BadRequest("Send Failed");
        }

        [HttpPost("receive-order"), Authorize(Roles = "SalesStaff, DeliveryStaff")]
        public async Task<IActionResult> ReceiveOrder(StaffReceiveDto order)
        {
            string currentRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (currentRole.IsNullOrEmpty())
            {
                return Unauthorized();
            }
            bool resultSuccess = await _serviceFactory.GetOrderService().ChangeStaffOrStatus(order, currentRole);
            return resultSuccess ? Ok("Update Success") : BadRequest("Update Failed");
        }

        [HttpDelete, Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            return await _serviceFactory.GetOrderService().DeleteOrder(id) ? Ok("Delete Success") : BadRequest("Delete Failed");
        }
    }
}