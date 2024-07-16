using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Email;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailsController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public EmailsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailDto sendEmailDto)
        {
            await _serviceFactory.GetEmailService().SendSingleEmail(sendEmailDto);
            return Ok();
        }
        
    }
}