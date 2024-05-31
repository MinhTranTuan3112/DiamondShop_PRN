using DiamondShop.DataAccess.DTOs.Diamond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.ProductPart
{
    public class GetProductPartDto
    {
        public Guid Id { get; set; }

        public bool? IsMain { get; set; }

        public Guid ProductId { get; set; }

        public Guid DiamondId { get; set; }

        public GetDiamondDto? Diamond { get; set; }
    }
}
