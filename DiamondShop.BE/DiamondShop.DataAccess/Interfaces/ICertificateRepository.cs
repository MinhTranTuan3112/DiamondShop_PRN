using DiamondShop.DataAccess.DTOs.Certificate;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Interfaces;

public interface ICertificateRepository : IGenericRepository<Certificate>
{
    Task<Certificate?> GetCertificateByReportNameAndOrigin(string origin, string reportNumber);

    Task<Certificate?> GetCertificateWithDiamondByReportNameAndOrigin(string origin, string reportNumber);
    Task<Certificate?> GetCertificateById(Guid id);

    Task<PagedResult<Certificate>> GetPagedCertificates(QueryCertificateDto queryCertificateDto);
}