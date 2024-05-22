using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Auth
{
    public class GetAuthTokenDto
    {
        public required string AccessToken { get; set; }
    }
}