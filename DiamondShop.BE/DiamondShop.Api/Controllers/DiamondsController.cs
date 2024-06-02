using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
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
    }
}
