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
            this._context = context;
        }

        public async Task<Diamond?> GetDiamondDetailsById(Guid id)
        {
            return await _context.Diamonds.AsNoTracking()
                                         .Include(d => d.Pictures)
                                         .Include(d => d.ProductParts)
                                         .AsSplitQuery()
                                         .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Diamond?> GetDiamondWithPicturesById(Guid id)
        {
            return await _context.Diamonds.Include(d => d.Pictures)
                                         .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<PagedResult<Diamond>> GetPagedDiamonds(QueryDiamondDto queryDiamondDto)
        {
            var (pageNumber, pageSize, sortBy, orderByDesc) = queryDiamondDto.QueryDto;
            var query = _context.Diamonds.AsNoTracking()
                                         .Include(d => d.Pictures)
                                         .AsSplitQuery()
                                         .AsQueryable();
            query = query.ApplyDiamondsFilter(queryDiamondDto);
            query = orderByDesc ? query.OrderByDescending(GetSortProperty(sortBy))
                                : query.OrderBy(GetSortProperty(sortBy));
            return await query.ToPaginationResultAsync(pageNumber, pageSize);
        }

        private Expression<Func<Diamond, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "lastUpdate" => diamond => (diamond.LastUpdate == null) ? diamond.Id : diamond.LastUpdate,
                "price" => diamond => diamond.Price,
                //"name" => diamond => diamond.Name!,
                _ => diamond => diamond.Id
            };
        }
    }
}
