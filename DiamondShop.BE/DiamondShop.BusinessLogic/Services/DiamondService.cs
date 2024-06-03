using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
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
    public class DiamondService : IDiamondService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiamondService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetDiamondIdDto> CreateDiamond(CreateDiamondDto createDiamondDto)
        {
            var diamond = await _unitOfWork.GetDiamondRepository().AddAsync(createDiamondDto.Adapt<Diamond>());
            await _unitOfWork.SaveChangesAsync();

            return new GetDiamondIdDto { Id = diamond.Id };
        }

        public async Task<PagedResult<GetDiamondInPageResultDto>> GetPageDiamonds(QueryDiamondDto queryDiamondDto)
        {
            if (queryDiamondDto.StartPrice > queryDiamondDto.EndPrice)
            {
                throw new BadRequestException("Start price must be less than end price");
            }

            return (await _unitOfWork.GetDiamondRepository().GetPagedDiamonds(queryDiamondDto)).Adapt<PagedResult<GetDiamondInPageResultDto>>();
        }

        public async Task UpdateDiamond(Guid id, UpdateDiamondDto updateDiamondDto)
        {
            var diamond = await _unitOfWork.GetDiamondRepository().FindOneAsync(d => d.Id == id);
            if (diamond is null)
            {
                throw new NotFoundException($"Can't find any diamonds with id {id}");
            }

            updateDiamondDto.Adapt(diamond);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
