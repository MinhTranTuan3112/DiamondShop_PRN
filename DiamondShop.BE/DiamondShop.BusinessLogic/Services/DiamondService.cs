using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Http;
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
        private readonly IServiceFactory _serviceFactory;

        public DiamondService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory)
        {
            _unitOfWork = unitOfWork;
            _serviceFactory = serviceFactory;
        }

        public async Task<GetDiamondIdDto> CreateDiamond(CreateDiamondDto createDiamondDto)
        {
            var diamond = createDiamondDto.Adapt<Diamond>();

            await _unitOfWork.GetDiamondRepository().AddAsync(diamond);
            await _unitOfWork.SaveChangesAsync();

            if (createDiamondDto.DiamondImages is not [])
            {
                await _serviceFactory.GetPictureService().UploadDiamondPictures(createDiamondDto.DiamondImages, diamond.Id);
            }


            return new GetDiamondIdDto { Id = diamond.Id };
        }

        public async Task<GetDiamondDetailsDto> GetDiamondDetailsById(Guid id)
        {
            var diamond = await _unitOfWork.GetDiamondRepository().GetDiamondDetailsById(id);

            if (diamond is null)
            {
                throw new NotFoundException($"Can't find any diamonds with id {id}");
            }

            return diamond.Adapt<GetDiamondDetailsDto>();
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
            var diamond = await _unitOfWork.GetDiamondRepository().GetDiamondWithPicturesById(id);
            if (diamond is null)
            {
                throw new NotFoundException($"Can't find any diamonds with id {id}");
            }

            updateDiamondDto.Adapt(diamond);

            diamond.LastUpdate = DateTime.Now;

            if (diamond.Pictures.Any())
            {
                await _serviceFactory.GetPictureService().DeletePictures(diamond.Pictures);

                diamond.Pictures.Clear();
            }
            
            await _unitOfWork.SaveChangesAsync();


            if (updateDiamondDto.DiamondImages is not [])
            {
                await _serviceFactory.GetPictureService().UploadDiamondPictures(updateDiamondDto.DiamondImages, diamond.Id);
            }


        }
    }
}
