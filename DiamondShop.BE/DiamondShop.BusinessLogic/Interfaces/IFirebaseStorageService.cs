using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IFirebaseStorageService
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string? imageName = default);

        string GetImageUrl(string imageName);

        Task<string> UpdateImageAsync(IFormFile imageFile, string imageName);

        Task DeleteImageAsync(string imageUrl);

        Task DeleteImagesAsync(List<string> imageUrls);

        Task<string[]> UploadImagesAsync(List<IFormFile> imageFiles);
    }
}