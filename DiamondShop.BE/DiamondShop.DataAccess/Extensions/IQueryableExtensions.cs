using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Models;
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

        public static IQueryable<Product> ApplyProductsFilter(this IQueryable<Product> query, QueryProductDto queryProductDto)
        {
            var (_, startPrice, endPrice, categoryIds, material, diamondIds) = queryProductDto;

            if (startPrice < endPrice)
            {
                query = query.Where(p => p.Price >= startPrice && p.Price <= endPrice);
            }

            if (categoryIds is not [])
            {
                query = query.Where(p => categoryIds.Contains(p.CategoryId));
            }

            if (!string.IsNullOrEmpty(material))
            {
                query = query.Where(p => !string.IsNullOrEmpty(p.Material) && p.Material.ToLower().Contains(material.ToLower()));
            }

            if (diamondIds is not [])
            {
                query = query.Where(p => p.ProductParts.Any(pp => diamondIds.Contains(pp.DiamondId)));
            }



            return query;
        }
    }
}