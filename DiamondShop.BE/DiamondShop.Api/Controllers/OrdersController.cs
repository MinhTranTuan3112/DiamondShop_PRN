using System.Security.Claims;
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

        [HttpGet("{id}&&{includeDetail}"), Authorize(Roles = "Manager, SalesStaff, DeliveryStaff, Customer")]
        public async Task<IActionResult> ViewOrder([FromRoute] Guid id, [FromRoute] bool includeDetail)
        {
            return Ok(await _serviceFactory.GetOrderService().GetOrderById(id, includeDetail));
        }

        [HttpPost("list"), Authorize(Roles = "Manager, SalesStaff, DeliveryStaff, Customer")]
        public async Task<IActionResult> ViewList(QueryOrderDto query)
        {
            return Ok(await _serviceFactory.GetOrderService().GetList(query));
        }

        [HttpPost("add-to-cart"), Authorize(Roles = "Customer")]
        public async Task<ActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            await _serviceFactory.GetOrderService().AddToCart(addToCartDto, HttpContext.User);
            return Ok();
        }

        [HttpPatch("status"), Authorize(Roles = "Manager, SalesStaff, DeliveryStaff, Customer")]
        public async Task<IActionResult> ChangeStatus([FromBody] OrderStatusDto ord)
        {
            string currentRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (currentRole is null)
            {
                return Unauthorized();
            }

            var result = await _serviceFactory.GetOrderService().UpdateStatus(ord.Id, ord.Status, currentRole);
            return result ? Ok("Change Success") : BadRequest("Change Failed");
        }

        [HttpPatch("update"), Authorize(Roles = "Manager, SalesStaff, DeliveryStaff, Customer")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderInfoDto ord)
        {
            string currentRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (currentRole is null)
            {
                return Unauthorized();
            }

            var result = await _serviceFactory.GetOrderService().UpdateOrder(ord);
            return result ? Ok("Change Success") : BadRequest("Change Failed");
        }

        [HttpDelete("{id}"), Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteOrder([FromRoute]Guid id)
        {
            var result = await _serviceFactory.GetOrderService().DeleteOrder(id);
            return result ? Ok("Delete Success") : BadRequest("Delete Failed");
        }
    }
}