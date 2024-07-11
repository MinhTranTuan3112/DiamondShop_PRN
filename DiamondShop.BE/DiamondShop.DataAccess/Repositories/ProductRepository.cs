using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Extensions;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository

    {
        private readonly FlashyCarbonDbContext _context;

        public ProductRepository(FlashyCarbonDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Product?> GetProductDetailById(Guid id)
        {
            var product = await _context.Products
                                .Include(p => p.Category)
                                .Include(p => p.ProductParts)
                                .ThenInclude(pp => pp.Diamond)
                                .Include(p => p.Pictures)
                                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<PagedResult<Product>> GetPagedProducts(QueryProductDto queryProductDto)
        {
            int pageNumber = queryProductDto.PageNumber;
            int pageSize = queryProductDto.PageSize;
            string sortBy = queryProductDto.SortColumn;
            bool orderByDesc = queryProductDto.OrderByDesc;

            var query = _context.Products.AsNoTracking()
                                        .Include(p => p.Pictures)
                                        .Include(p => p.Category)
                                        .Include(p => p.ProductParts)
                                        .AsSplitQuery()
                                        .AsQueryable();

            query = query.Where(p => p.Status != "Deleted");

            query = query.ApplyProductsFilter(queryProductDto);

            query = orderByDesc ? query.OrderByDescending(GetSortProperty(sortBy))
                                : query.OrderBy(GetSortProperty(sortBy));


            return await query.ToPaginationResultAsync(pageNumber, pageSize);
        }

        private Expression<Func<Product, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "lastUpdate" => product => (product.LastUpdate == null) ? product.Id : product.LastUpdate,
                "price" => product => product.Price,
                _ => product => product.Id
            };
        }

        public async Task<Product?> GetProductWithCategoryById(Guid id)
        {
            return await _context.Products.Include(p => p.Category)
                                          .SingleOrDefaultAsync(x => x.Id == id);
        }
    }


}
