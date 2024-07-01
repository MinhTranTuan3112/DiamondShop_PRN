using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public ProductsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        [HttpPost]
        // [Authorize(Roles = "SalesStaff, sales-staff")]
        public async Task<ActionResult<GetProductIdDto>> CreateProduct([FromForm] CreateProductDto createProductDto)
        {
            return Created(nameof(CreateProduct), await _serviceFactory.GetProductService().CreateProduct(createProductDto));
        }
        [HttpPost("{productId:guid}")]
        // [Authorize(Roles = "SalesStaff, sales-staff")]
        public async Task<ActionResult<GetProductIdDto>> CreateProductProperties(Guid productId, [FromBody] CreateProductPropetiesDto createProductPropertiesDto)
        {
            return Created(nameof(CreateProductProperties), await _serviceFactory.GetProductService().CreateProductProperties(productId, createProductPropertiesDto));
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] Guid id, [FromForm] UpdateProductDto updateProductDto)
        {
            await _serviceFactory.GetProductService().UpdateProduct(id, updateProductDto);
            return NoContent();
        }
        [HttpPut("ProductProperties/{productId:guid}")]
        public async Task<ActionResult> UpdateProductProperties([FromRoute] Guid productId, [FromBody] CreateProductPropetiesDto createProductPropertiesDto)
        {
            await _serviceFactory.GetProductService().UpdateProductProperties(productId, createProductPropertiesDto);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetProductInPagedResultDto>>> GetPagedProducts([FromQuery] QueryProductDto queryProductDto)
        {
            return await _serviceFactory.GetProductService().GetPagedProducts(queryProductDto);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDetailDto>> GetProducDetailtById(Guid id)
        {
            var result = await _serviceFactory.GetProductService().GetProductDetailById(id);
            return result;
        }
    }
}