using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.ProductPart
{
    public class CreateProductPartDto
    {
        public bool? IsMain { get; set; }

        public Guid DiamondId { get; set; }
    }
}
