using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<PagedResult<Product>> GetPagedProducts(QueryDto queryDto)
        {
            var (pageNumber, pageSize, sortBy, orderByDesc) = queryDto;
            var query = _context.Products.Include(p => p.Pictures)
                                        .AsQueryable();




            return await query.ToPaginationResultAsync<Product>(pageNumber, pageSize);
        }



    }
}