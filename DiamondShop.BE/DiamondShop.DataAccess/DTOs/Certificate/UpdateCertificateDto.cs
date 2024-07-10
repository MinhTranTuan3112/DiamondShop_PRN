using System.ComponentModel.DataAnnotations;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.DataAccess.DTOs.Certificate;

public class UpdateCertificateDto
{
    [Required]
    public required string ReportNumber { get; set; }
    [Required]
    [EnumDataType(typeof(DiamondOrigin))]
    public required string Origin { get; set; } 
    
    public string? Shape { get; set; } 
    
    [EnumDataType(typeof(DiamondColor))]
    public string? Color { get; set; }
    
    [EnumDataType(typeof(DiamondClarity))]
    public string? Clarity { get; set; }
    
    [EnumDataType(typeof(DiamondCut))]
    public string? Cut { get; set; } 
    
    public string? CaratWeight { get; set; } 

    public DateTime DateOfIssue { get; set; }
}