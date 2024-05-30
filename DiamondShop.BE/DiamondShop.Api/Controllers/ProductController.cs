using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;
        public ProductController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDetailDto>> GetProductById(Guid id)
        {
            var result = await _serviceFactory.GetProductService().GetProductAsync(id);
            return result;
        }
    }
}
