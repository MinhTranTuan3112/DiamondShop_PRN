using DiamondShop.DataAccess.DTOs.Certificate;

namespace DiamondShop.BusinessLogic.Interfaces;

public interface ICertificateService
{
    Task<GetCertificateIdDto> CreateCertificate(CreateCertificateDto createCertificateDto);
    Task UpdateCertificate(Guid id, UpdateCertificateDto updateCertificateDto);

    Task<GetCertificateDetailDto> GetCertificateByOriginAndReportNumberForCreateDiamond(string origin, string reportNumber);

    Task<List<GetListCertificateDto>> GetAllCertificates();
}