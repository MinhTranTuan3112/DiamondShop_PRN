using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Repositories;

public class CertificateRepository : GenericRepository<Certificate>, ICertificateRepository
{
    private readonly FlashyCarbonDbContext _context;

    public CertificateRepository(FlashyCarbonDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Certificate?> GetCertificateByReportNameAndOrigin(string origin, string reportNumber)
    {
        return await _context.Certificates.SingleOrDefaultAsync(x => x.Origin == origin && x.ReportNumber == reportNumber);
    }

    public async Task<Certificate?> GetCertificateWithDiamondByReportNameAndOrigin(string origin, string reportNumber)
    {
        return await _context.Certificates.Include(x => x.Diamond)
                                            .SingleOrDefaultAsync(x => x.Origin == origin && x.ReportNumber == reportNumber); 
    }

    public async Task<Certificate?> GetCertificateById(Guid id)
    {
        return await _context.Certificates.Include(x => x.Diamond).SingleOrDefaultAsync(x => x.Id == id);
    }
}