using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiamondsController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public DiamondsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<GetDiamondInPageResultDto>>> GetPagedProducts([FromQuery] QueryDiamondDto queryDiamondDto)
        {
            return await _serviceFactory.GetDiamondService().GetPageDiamonds(queryDiamondDto);
        }

        [HttpPost]
        // [Authorize(Roles = "SalesStaff, sales-staff")]
        public async Task<ActionResult<GetDiamondIdDto>> CreateDiamond([FromBody] CreateDiamondDto createDiamondDto)
        {
            return Created(nameof(CreateDiamond), await _serviceFactory.GetDiamondService().CreateDiamond(createDiamondDto));
        }

        [HttpPut("{id:guid}")]
        // [Authorize(Roles = "SalesStaff, sales-staff")]
        public async Task<ActionResult> UpdateDiamond(Guid id, [FromBody] UpdateDiamondDto updateDiamondDto)
        {
            await _serviceFactory.GetDiamondService().UpdateDiamond(id, updateDiamondDto);
            return NoContent();
        }
    }
}
