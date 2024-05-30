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
            _context = context;
        }

        public async Task<PagedResult<Product>> GetPagedProducts(QueryProductDto queryProductDto)
        {

            var (pageNumber, pageSize, sortBy, orderByDesc) = queryProductDto.QueryDto;

            var query = _context.Products.AsNoTracking()
                                        .Include(p => p.Pictures)
                                        .Include(p => p.Category)
                                        .Include(p => p.ProductParts)
                                        .AsSplitQuery()
                                        .AsQueryable();

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





    }
}