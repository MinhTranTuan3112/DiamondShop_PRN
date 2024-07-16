using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Email
{
    public class SendEmailDto
    {
        
        public required string Subject { get; set; }

        public required string Body { get; set; }

        public required string ReceivedEmailAddress { get; set; }

    }
}