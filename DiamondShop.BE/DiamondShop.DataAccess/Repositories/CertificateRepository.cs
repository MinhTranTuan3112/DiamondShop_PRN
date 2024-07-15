using System.Linq.Expressions;
using DiamondShop.DataAccess.DTOs.Certificate;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Extensions;
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

    public async Task<PagedResult<Certificate>> GetPagedCertificates(QueryCertificateDto queryCertificateDto)
    {
        var (pageNumber, pageSize, sortBy, orderByDesc) = queryCertificateDto.QueryDto;
        var query = _context.Certificates.AsNoTracking().Include(x => x.Diamond).AsSplitQuery().AsQueryable();
        query = query.ApplyCertificateFilter(queryCertificateDto);
        query = orderByDesc ? query.OrderByDescending(GetSortProperty(sortBy)) : query.OrderBy(GetSortProperty(sortBy));
        return await query.ToPaginationResultAsync(pageNumber, pageSize);
    }
    private Expression<Func<Certificate, object>> GetSortProperty(string sortColumn)
    {
        return sortColumn.ToLower() switch
        {
            "dateOfIssue" => c => c.DateOfIssue,
            _ => c => c.Id
        };
    }
}