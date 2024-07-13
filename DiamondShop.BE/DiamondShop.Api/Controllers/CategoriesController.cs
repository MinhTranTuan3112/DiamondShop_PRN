using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Category;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public CategoriesController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost]
        public async Task<ActionResult<GetCategoryDto>> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            return Created(nameof(CreateCategory), await _serviceFactory.GetCategoryService().CreateCategory(createCategoryDto));
        }
        
        [HttpGet]
        public async Task<ActionResult<List<GetCategoryDto>>> GetAllCategory()
        {
            return await _serviceFactory.GetCategoryService().GetAllCategories();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            await _serviceFactory.GetCategoryService().UpdateCategory(id, updateCategoryDto);
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetCategoryDto>> GetCategoryById(Guid id)
        {
            return await _serviceFactory.GetCategoryService().GetCategoryById(id);
        }
        
        [HttpPut("{categoryId:guid}/{status}")]
        public async Task<ActionResult> ChangeStatusCategory(Guid categoryId, CategoryStatus status)
        {
            await _serviceFactory.GetCategoryService().ChangStatusCategory(categoryId, status);
            return NoContent();
        }
    }
}
