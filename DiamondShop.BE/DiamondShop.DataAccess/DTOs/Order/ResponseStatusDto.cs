using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.DTOs.Order
{
    public class ResponseStatusDto
    {
        public Guid OrderId { get; set; }
        public Guid StakeholderId { get; set; }
        [Required] public required string UpdatedStatus { get; set; }
    }
}
