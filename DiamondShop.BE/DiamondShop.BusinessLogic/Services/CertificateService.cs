

using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Certificate;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Mapster;
namespace DiamondShop.BusinessLogic.Services;

public class CertificateService : ICertificateService
{
    private readonly IUnitOfWork _unitOfWork;

    public CertificateService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<GetCertificateIdDto> CreateCertificate(CreateCertificateDto createCertificateDto)
    {
        var certificate = await _unitOfWork.GetCertificateRepository()
            .GetCertificateByReportNameAndOrigin(createCertificateDto.Origin, createCertificateDto.ReportNumber);
        if (certificate is not null)
        {
            throw new BadRequestException("Certificate is already existed");
        }
        var newCertificate = createCertificateDto.Adapt<Certificate>();
        await _unitOfWork.GetCertificateRepository().AddAsync(newCertificate);
        await _unitOfWork.SaveChangesAsync();
        return new GetCertificateIdDto
        {
            Id = newCertificate.Id
        };
    }

    public async Task UpdateCertificate(Guid id, UpdateCertificateDto updateCertificateDto)
    {
        var certificate = await _unitOfWork.GetCertificateRepository().GetCertificateById(id);
        
        if (certificate is null)
        {
            throw new NotFoundException("Certificate is not existed");
        }
        var existingCertificate = await _unitOfWork.GetCertificateRepository()
            .GetCertificateByReportNameAndOrigin(updateCertificateDto.Origin, updateCertificateDto.ReportNumber);

        if (existingCertificate is not null && existingCertificate.Id != id)
        {
            throw new BadRequestException("Another certificate with the same origin and report number already exists");
        }

        updateCertificateDto.Adapt(certificate);
        if (certificate.Diamond is not null)
        {
            updateCertificateDto.Adapt(certificate.Diamond);
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<GetCertificateDetailDto> GetCertificateByOriginAndReportNumberForCreateDiamond(string origin, string reportNumber)
    {
        var certificate = await _unitOfWork.GetCertificateRepository()
            .GetCertificateWithDiamondByReportNameAndOrigin(origin, reportNumber);
        if (certificate is null)
        {
            throw new NotFoundException("Certificate is not existed");
        }

        if (certificate.Diamond is not null)
        {
            throw new BadRequestException("This certificate is already related with another diamond");
        }

        return certificate.Adapt<GetCertificateDetailDto>();
    }

    public async Task<List<GetListCertificateDto>> GetAllCertificates()
    {
        var certificates = await _unitOfWork.GetCertificateRepository().GetAllAsync();
        return certificates.Adapt<List<GetListCertificateDto>>();
    }
    
}