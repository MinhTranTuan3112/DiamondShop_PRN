using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Promotion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;
        public PromotionsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetPromotions(int pageIndex = 1, int pageSize = 10, string searchString = "", DateTime expireDate = new DateTime())
        {
            var (data, totalCount) = await _serviceFactory.GetPromotionService().GetPromotions(pageIndex, pageSize, searchString, expireDate);
            return Ok(new { data, totalCount });
        }


        [HttpGet("{code}")]
        public async Task<IActionResult> GetPromotionByCode(string code)
        {
            var promotion = await _serviceFactory.GetPromotionService().GetPromotionByCode(code);
            return Ok(promotion);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion([FromQuery] CreatePromotion createPromotion)
        {
            await _serviceFactory.GetPromotionService().CreatePromotion(createPromotion);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePromotion([FromQuery] UpdatePromotion updatePromotion)
        {
            await _serviceFactory.GetPromotionService().UpdatePromotion(updatePromotion);
            return Ok("Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePromotion(Guid id)
        {
            await _serviceFactory.GetPromotionService().DeletePromotion(id);
            return Ok("Deleted");
        }
    }
}
