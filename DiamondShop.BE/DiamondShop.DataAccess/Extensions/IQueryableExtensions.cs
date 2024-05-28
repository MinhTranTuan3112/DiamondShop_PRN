using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Query;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PagedResult<T>> ToPaginationResultAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        where T : class
        {
            
            return new PagedResult<T>
            {
                TotalCount = await query.CountAsync(),
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Results = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync()
            };
        }
    }
}