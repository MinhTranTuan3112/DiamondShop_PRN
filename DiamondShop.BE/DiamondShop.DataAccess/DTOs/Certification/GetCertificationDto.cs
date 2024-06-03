using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Certification
{
    public class GetCertificationDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? UrlPath { get; set; }

        public Guid DiamondId { get; set; }
    }
}