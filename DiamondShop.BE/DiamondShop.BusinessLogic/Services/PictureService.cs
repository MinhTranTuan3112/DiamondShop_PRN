using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Microsoft.AspNetCore.Http;

namespace DiamondShop.BusinessLogic.Services
{
    public class PictureService : IPictureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceFactory _serviceFactory;

        public PictureService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory)
        {
            _unitOfWork = unitOfWork;
            _serviceFactory = serviceFactory;
        }

        public async Task UploadDiamondPictures(List<IFormFile> pictureFiles, Guid diamondId)
        {
            if (pictureFiles is [])
            {
                throw new BadRequestException("No picture files found");
            }

            var pictureUrls = await _serviceFactory.GetFirebaseStorageService().UploadImagesAsync(pictureFiles);

            List<Picture> pictures = [];

            foreach (var url in pictureUrls)
            {
                pictures.Add(new Picture
                {
                    DiamondId = diamondId,
                    UrlPath = url
                });
            }


            await _unitOfWork.GetPictureRepository().AddRangeAsync(pictures);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}