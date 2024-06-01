using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Interfaces;
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
        public async Task<PagedResult<GetDiamondInPageResultDto>> GetPageDiamonds(QueryDiamondDto queryDiamondDto)
        {
            if (queryDiamondDto.StartPrice > queryDiamondDto.EndPrice)
            {
                throw new BadRequestException("Start price must be less than end price");
            }

            return (await _unitOfWork.GetDiamondRepository().GetPagedDiamonds(queryDiamondDto)).Adapt<PagedResult<GetDiamondInPageResultDto>>();
        }
    }
}
