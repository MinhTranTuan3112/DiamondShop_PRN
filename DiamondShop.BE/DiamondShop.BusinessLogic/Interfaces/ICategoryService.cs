using DiamondShop.DataAccess.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        Task<GetCategoryDto> CreateCategory(CreateCategoryDto createCategoryDto);
        Task UpdateCategory(Guid id, UpdateCategoryDto updateCategoryDto);

        Task<GetCategoryDto> GetCategoryById(Guid id);
        Task <List<GetCategoryDto>> GetAllCategories();
        //Task DeleteCategory (Guid id);
        Task ChangStatusCategory(Guid categoryId, CategoryStatus status);
    }
}
