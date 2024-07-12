using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Diamond;
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
            decimal startPrice = queryProductDto.StartPrice;
            decimal endPrice = queryProductDto.EndPrice;
            var categoryIds = queryProductDto.CategoryIds;
            var name = queryProductDto.Name;
            var material = queryProductDto.Material;
            var diamondIds = queryProductDto.DiamondIds;
            var types = queryProductDto.Types;

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

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(name.ToLower()));
            }

            if (diamondIds is not [])
            {
                query = query.Where(p => p.ProductParts.Any(pp => diamondIds.Contains(pp.DiamondId)));
            }

            if (!string.IsNullOrEmpty(queryProductDto.Name))
            {
                query = query.Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(queryProductDto.Name.ToLower()));
            }

            if (types is not [])
            {
                query = query.Where(p => types.Contains(p.Type));
            }

            return query;
        }
        public static IQueryable<Diamond> ApplyDiamondsFilter(this IQueryable<Diamond> query, QueryDiamondDto queryDiamondDto)
        {
            var startPrice = queryDiamondDto.StartPrice;
            var endPrice = queryDiamondDto.EndPrice;
            var name = queryDiamondDto.Name;
            var colors = queryDiamondDto.Colors;
            var cuts = queryDiamondDto.Cuts;
            var clarities = queryDiamondDto.Clarities;
            if (startPrice < endPrice)
            {
                query = query.Where(p => p.Price >= startPrice && p.Price <= endPrice);
            }
            // if (!string.IsNullOrEmpty(name))
            // {
            //     query = query.Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(name.ToLower()));
            // }

            if (colors is not [])
            {
                query = query.Where(p => colors.Contains(p.Color!));
            }
            if (clarities is not [])
            {
                query = query.Where(p => clarities.Contains(p.Clarity!));
            }
            if (cuts is not [])
            {
                query = query.Where(p => cuts.Contains(p.Cut!));
            }
            return query;
        }
    }
}