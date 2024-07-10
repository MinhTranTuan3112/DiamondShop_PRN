using System.ComponentModel.DataAnnotations;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.DataAccess.DTOs.Certificate;

public class CreateCertificateDto
{
    [Required]
    public required string ReportNumber { get; set; }
    [Required]
    [EnumDataType(typeof(DiamondOrigin))]
    public required string Origin { get; set; } 
    [Required]
    public required string Shape { get; set; } 
    [Required]
    [EnumDataType(typeof(DiamondColor))]
    public required string Color { get; set; } 
    [Required]
    [EnumDataType(typeof(DiamondClarity))]
    public required string Clarity { get; set; } 
    [Required]
    [EnumDataType(typeof(DiamondCut))]
    public required string Cut { get; set; } 
    [Required]
    public required string CaratWeight { get; set; } 

    public DateTime DateOfIssue { get; set; }
}