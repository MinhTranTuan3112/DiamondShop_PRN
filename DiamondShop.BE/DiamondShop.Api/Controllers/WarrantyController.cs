using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Warranty;
using DiamondShop.DataAccess.Enums;
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
            return Ok(await _serviceFactory.GetWarrantyService().GetWarranties_Of_OrderDetailAsync(odetailId));
        }


        [HttpPost("list")]
        public async Task<IActionResult> GetFiltered_List_WarrantyAsync([FromBody] WarrantyFilterDto filtered)
        {
            return Ok(await _serviceFactory.GetWarrantyService().GetFiltered_List_WarrantyAsync(filtered));
        }
        
        [HttpPost("new-warranty")]
        public async Task<IActionResult> AddNewWarranty([FromBody] WarrantyNewDto warrantyNew)
        {
            return Ok(await _serviceFactory.GetWarrantyService().CreateWarrantyAsync(warrantyNew));
        }

        [HttpPatch("warranty-editor")]
        public async Task<IActionResult> UpdateWarranty([FromBody]WarrantyUpdateDto warDto)
        {
            return (await _serviceFactory.GetWarrantyService().UpdateWarrantyAsync(warDto))
                ?Ok("Update Success") :BadRequest("Update Failed");
        }
        
        [HttpPatch("new-status/{warrantyId}/{enumStatus}")]
        public async Task<IActionResult> ChangeStatus([FromRoute]Guid warrantyId, [FromRoute]WarrantyStatus enumStatus)
        {
            return (await _serviceFactory.GetWarrantyService().ChangeStatus(warrantyId, enumStatus))
                ?Ok("Update Success") :BadRequest("Update Failed");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarranty([FromRoute]Guid id)
        {
            return (await _serviceFactory.GetWarrantyService().DeleteWarrantyAsync(id))
                ?Ok("Delete Success!"):BadRequest("Delete Failed!");
        }
    }
}
