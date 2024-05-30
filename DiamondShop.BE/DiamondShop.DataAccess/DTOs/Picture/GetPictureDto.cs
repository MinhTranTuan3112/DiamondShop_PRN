using DiamondShop.DataAccess.DTOs.Diamond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Picture
{
    public class GetPictureDto
    {
        public Guid Id { get; set; }

        public string? UrlPath { get; set; }


    }
}
