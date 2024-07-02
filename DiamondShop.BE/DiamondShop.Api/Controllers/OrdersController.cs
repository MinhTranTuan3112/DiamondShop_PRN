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
        [HttpGet("{id}&&{includeDetail}"), Authorize(Roles = "Manager, SalesStaff, DeliveryStaff, Customer")]
        public async Task<IActionResult> ViewOrder(Guid id, bool includeDetail)
        {
            return Ok(await _serviceFactory.GetOrderService().GetOrderById(id, includeDetail));
        }

        [HttpPost("Status"), Authorize(Roles = "Manager, SalesStaff, DeliveryStaff, Customer")]
        public async Task<IActionResult> ChangeStatus(OrderStatusDto ord)
        {
            string currentRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (currentRole is null)
            {
                return Unauthorized();
            }

            var result = await _serviceFactory.GetOrderService().UpdateStatus(ord.Id, ord.Status, currentRole);
            return result ? Ok("Change Success") : BadRequest("Change Failed");
        }

        [HttpPost("Update"), Authorize(Roles = "Manager, SalesStaff, DeliveryStaff, Customer")]
        public async Task<IActionResult> UpdateOrder(OrderInfoDto ord)
        {
            string currentRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (currentRole is null)
            {
                return Unauthorized();
            }

            var result = await _serviceFactory.GetOrderService().UpdateOrder(ord);
            return result ? Ok("Change Success") : BadRequest("Change Failed");
        }

        [HttpDelete, Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var result = await _serviceFactory.GetOrderService().DeleteOrder(id);
            return result ? Ok("Delete Success") : BadRequest("Delete Failed");
        }
    }
}