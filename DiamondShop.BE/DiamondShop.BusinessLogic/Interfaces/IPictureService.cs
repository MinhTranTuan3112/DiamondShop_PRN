using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IPictureService
    {
        Task UploadDiamondPictures(List<IFormFile> pictureFiles, Guid diamondId);
    }
}