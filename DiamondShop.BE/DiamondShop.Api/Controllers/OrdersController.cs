using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.Enums;
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

        [HttpPost("add-to-cart"), Authorize(Roles = "Customer, customer")]
        public async Task<ActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            await _serviceFactory.GetOrderService().AddToCart(addToCartDto, HttpContext.User);
            return Ok();
        }

        [HttpPost("receive-order"), Authorize(Roles = "SalesStaff, DeliveryStaff")]
        public async Task<IActionResult> ReceiveOrder(ResponseStatusDto order)
        {
            var userClaims = User.Claims.ToList();
            if (userClaims.Any())
            {
                string currentRole = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                bool resultSuccess = await _serviceFactory.GetOrderService().ChangeStaffOrStatus(order, currentRole);
                return resultSuccess ? Ok("Update Success") : BadRequest("Update Failed");
            }
            return Unauthorized();
        }
    }
}