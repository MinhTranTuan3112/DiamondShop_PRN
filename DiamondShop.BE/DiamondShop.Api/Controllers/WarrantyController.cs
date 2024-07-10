using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Warranty;
using DiamondShop.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantyController : Controller
    {
        private readonly IServiceFactory _serviceFactory;
        public WarrantyController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ViewDetail ([FromRoute] Guid id)
        {
            return Ok(await _serviceFactory.GetWarrantyService().GetDetailAsync(id));
        }

        [HttpGet("order-detail/{odetailId}")]
        public async Task<IActionResult> GetListByOrderDetail([FromRoute] Guid odetailId)
        {
            return Ok(await _serviceFactory.GetWarrantyService().GetWarranties_Of_OrderDetail(odetailId));
        }

        [HttpPost("new-warranty")]
        public async Task<IActionResult> AddNewWarranty([FromBody] WarrantyNewDto warrantyNew)
        {
            return Ok(await _serviceFactory.GetWarrantyService().CreateWarranty(warrantyNew));
        }
    }
}
