using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Email;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IEmailService
    {
        Task SendSingleEmail(SendEmailDto sendEmailDto, bool hasHtmlBody = true);

        Task SendOrderEmail(Order order);
    }
}