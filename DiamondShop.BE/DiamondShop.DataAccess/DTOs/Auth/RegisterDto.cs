using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.DataAccess.DTOs.Auth
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        [EnumDataType(typeof(Role))]
        public required string Role { get; set; }
    }
}