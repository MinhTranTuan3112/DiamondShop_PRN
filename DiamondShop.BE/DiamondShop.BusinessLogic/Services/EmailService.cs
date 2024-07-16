using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Email;
using DiamondShop.DataAccess.Models;
using FluentEmail.Core;
using Razor.Templating.Core;

namespace DiamondShop.BusinessLogic.Services
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmailFactory _fluentEmailFactory;
        
        private readonly IRazorTemplateEngine _razorTemplateEngine;

        public EmailService(IFluentEmailFactory fluentEmailFactory, IRazorTemplateEngine razorTemplateEngine)
        {
            _fluentEmailFactory = fluentEmailFactory;
            _razorTemplateEngine = razorTemplateEngine;
        }

        public async Task SendOrderEmail(Order order)
        {
            var emailBody = await _razorTemplateEngine.RenderAsync("Views/OrderEmailTemplate.cshtml", order);

            var sendEmailDto = new SendEmailDto
            {
                ReceivedEmailAddress = order.Customer.Account.Email!,
                Subject = "Thông tin đơn hàng - MAPTH",
                Body = emailBody
            };

            await SendSingleEmail(sendEmailDto);
        }

        public async Task SendSingleEmail(SendEmailDto sendEmailDto, bool hasHtmlBody = true)
        {
            var email = _fluentEmailFactory.Create();
            email.To(sendEmailDto.ReceivedEmailAddress);
            email.Subject(sendEmailDto.Subject);
            email.Body(sendEmailDto.Body, hasHtmlBody);
            await email.SendAsync();
        }
    }
}