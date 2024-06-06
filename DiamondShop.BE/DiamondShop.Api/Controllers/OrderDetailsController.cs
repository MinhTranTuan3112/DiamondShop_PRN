using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : Controller
    {
        private readonly IServiceFactory _serviceFactory;
        public OrderDetailsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet(), Authorize(Roles = "Manager,SalesStaff,Customer")]
        public async Task<IActionResult> GetAll(Guid orderId)
        {
            var result = await _serviceFactory.GetOrderDetailService().GetListByOrderId(orderId);
            return result is null? BadRequest("Wrong OrderId or not exist") : Ok(result);
        }
    }
}
