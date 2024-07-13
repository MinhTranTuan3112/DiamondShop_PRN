using DiamondShop.DataAccess.DTOs.Certificate;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.BusinessLogic.Interfaces;

public interface ICertificateService
{
    Task<GetCertificateIdDto> CreateCertificate(CreateCertificateDto createCertificateDto);
    Task UpdateCertificate(Guid id, UpdateCertificateDto updateCertificateDto);

    Task<GetCertificateDetailDto> GetCertificateByOriginAndReportNumberForCreateDiamond(string origin, string reportNumber);

    //Task<List<GetListCertificateDto>> GetAllCertificates();
    Task<PagedResult<GetListCertificateDto>> GetPageCertificates(QueryCertificateDto queryCertificateDto);

    Task<GetCertificateByIdDto> GetCertificateById(Guid id);
    
    Task ChangStatusCertificate(Guid id, CertificateStatus status);
    
    
}