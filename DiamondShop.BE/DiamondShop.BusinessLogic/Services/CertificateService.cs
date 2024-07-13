using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Certificate;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
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

    public async Task<PagedResult<GetListCertificateDto>> GetPageCertificates(QueryCertificateDto queryCertificateDto)
    {
        if (queryCertificateDto.StartDateOfIssue > queryCertificateDto.EndDateOfIssue)
        {
            throw new BadRequestException("Start date must be less than the end date ");
        }

        return (await _unitOfWork.GetCertificateRepository().GetPagedCertificates(queryCertificateDto))
            .Adapt<PagedResult<GetListCertificateDto>>();
    }

    public async Task<GetCertificateByIdDto> GetCertificateById(Guid id)
    {
        var certificate = await _unitOfWork.GetCertificateRepository().GetCertificateById(id);
        if (certificate is null)
        {
            throw new NotFoundException("Certificate is not existed");
        }

        return certificate.Adapt<GetCertificateByIdDto>();
    }

    public async Task ChangStatusCertificate(Guid id, CertificateStatus status)
    {
        var certificate = await _unitOfWork.GetCertificateRepository().GetCertificateById(id);
        if (certificate is null)
        {
            throw new NotFoundException("Certificate is not existed");
        }

        certificate.Status = status switch
        {
            CertificateStatus.Available => CertificateStatus.Available.ToString().ToLower(),
            CertificateStatus.Unavailable => CertificateStatus.Unavailable.ToString().ToLower(),
            CertificateStatus.Deleted => CertificateStatus.Deleted.ToString().ToLower(),
            _ => certificate.Status
        };

        if (certificate.Diamond != null)
        {
            certificate.Diamond.Status = status switch
            {
                CertificateStatus.Available => ProductStatus.Available.ToString().ToLower(),
                CertificateStatus.Deleted => ProductStatus.Deleted.ToString().ToLower(),
                _ => certificate.Diamond.Status
            };
            certificate.Diamond.LastUpdate = DateTime.Now;
        }
        await _unitOfWork.SaveChangesAsync();
    }
}