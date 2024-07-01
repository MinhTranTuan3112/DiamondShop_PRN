using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public ImagesController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }


        [HttpPost("test-upload")]
        public async Task<ActionResult> TestUpload(IFormFile file)
        {
            
            return Created(nameof(TestUpload), await _serviceFactory.GetFirebaseStorageService().UploadImageAsync(file));
        }
    }
}