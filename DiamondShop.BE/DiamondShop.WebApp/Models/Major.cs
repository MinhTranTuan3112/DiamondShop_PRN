using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondShop.WebApp.Models
{
    public class Major
    {
        [Required]
        public required string Id { get; set; }

        [Required]

        public required string Code { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Name is too long")]
        public required string Name { get; set; }
    }
}