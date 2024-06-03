using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Category;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetCategoryDto> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = createCategoryDto.Adapt<Category>();
            category.Status = CategoryStatus.Available.ToString();
            category.LastUpdate = DateTime.Now;
            await _unitOfWork.GetCategoryRepository().AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return category.Adapt<GetCategoryDto>();
        }

        public async Task DeleteCategory(Guid id)
        {
            var category = await _unitOfWork.GetCategoryRepository().FindOneAsync(x => x.Id == id)
                ?? throw new NotFoundException("Category not found");
                
            if (category.Status == CategoryStatus.Deleted.ToString())
            {
                throw new BadRequestException("Category is already deleted");
            }

            category.Status = CategoryStatus.Deleted.ToString();
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GetCategoryDto>> GetAllCategories()
        {
            var categories = await _unitOfWork.GetCategoryRepository().GetAllAsync();
            return categories.Adapt<List<GetCategoryDto>>();

        }
        public async Task<GetCategoryDto> GetCategoryById(Guid id)
        {
            var category = await _unitOfWork.GetCategoryRepository().FindOneAsync(x => x.Id == id)
                ?? throw new NotFoundException("Can't find any category with this id");
                
            return category.Adapt<GetCategoryDto>();
        }

        public async Task UpdateCategory(Guid id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _unitOfWork.GetCategoryRepository().FindOneAsync(x => x.Id == id)
                ?? throw new NotFoundException("Can't find any category with this id");

            updateCategoryDto.Adapt(category);
            category.LastUpdate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
