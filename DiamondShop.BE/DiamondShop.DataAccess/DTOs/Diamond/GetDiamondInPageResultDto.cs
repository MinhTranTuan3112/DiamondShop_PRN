using DiamondShop.DataAccess.DTOs.Picture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Diamond
{
    public class GetDiamondInPageResultDto
    {
        public Guid Id { get; set; }
        
        public string? Shape { get; set; }

        public string? Color { get; set; }

        public string? Origin { get; set; }
        
        public string? CertificationUrl { get; set; }

        public string? CaratWeight { get; set; }

        public string? Clarity { get; set; }

        public string? Cut { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int WarrantyPeriod { get; set; }

        public DateTime? LastUpdate { get; set; }

        public string? Status { get; set; }
        public ICollection<GetPictureDto> Pictures { get; set; } = new List<GetPictureDto>();
    }
}
