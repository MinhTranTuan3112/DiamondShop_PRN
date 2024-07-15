using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Extensions;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.Repositories
{
    public class DiamondRepository : GenericRepository<Diamond>, IDiamondRepository
    {
        private readonly FlashyCarbonDbContext _context;

        public DiamondRepository(FlashyCarbonDbContext context) : base(context)
        {
           _context = context;
        }

        public async Task<Diamond?> GetDiamondDetailsById(Guid id)
        {
            return await _context.Diamonds.AsNoTracking()
                                         .Include(d => d.Pictures)
                                         .Include(d => d.ProductParts)
                                         .Include(d => d.Certificate)
                                         .AsSplitQuery()
                                         .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Diamond?> GetDiamondWithPicturesById(Guid id)
        {
            return await _context.Diamonds.Include(d => d.Pictures)
                                          .Include(d => d.Certificate)
                                         .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<PagedResult<Diamond>> GetPagedDiamonds(QueryDiamondDto queryDiamondDto)
        {
            int pageNumber = queryDiamondDto.PageNumber;
            int pageSize = queryDiamondDto.PageSize;
            string sortBy = queryDiamondDto.SortColumn;
            bool orderByDesc = queryDiamondDto.OrderByDesc;
            var query = _context.Diamonds.AsNoTracking()
                                         .Include(d => d.Pictures)
                                         .AsSplitQuery()
                                         .AsQueryable();
            query = query.Where(d => d.Status != "Deleted");
            query = query.ApplyDiamondsFilter(queryDiamondDto);
            query = orderByDesc ? query.OrderByDescending(GetSortProperty(sortBy))
                                : query.OrderBy(GetSortProperty(sortBy));
            return await query.ToPaginationResultAsync(pageNumber, pageSize);
        }

        private static Expression<Func<Diamond, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "lastUpdate" => diamond => diamond.LastUpdate,
                "price" => diamond => diamond.Price,
                //"name" => diamond => diamond.Name!,
                _ => diamond => diamond.Id
            };
        }
    }
}
