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
            var material = queryProductDto.Material;
            var diamondIds = queryProductDto.DiamondIds;

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
        public static IQueryable<Diamond> ApplyDiamondsFilter(this IQueryable<Diamond> query, QueryDiamondDto queryDiamondDto)
        {
            var startPrice = queryDiamondDto.StartPrice;
            var endPrice = queryDiamondDto.EndPrice;
            var name = queryDiamondDto.Name;
            var color = queryDiamondDto.Color;
            var origin = queryDiamondDto.Origin;
            var caratWeight = queryDiamondDto.CaratWeight;
            var clarity = queryDiamondDto.Clarity;
            var cut = queryDiamondDto.Cut;
            if (startPrice < endPrice)
            {
                query = query.Where(p => p.Price >= startPrice && p.Price <= endPrice);
            }
            if (!string.IsNullOrEmpty(name))
            {
                //query = query.Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(p =>  !string.IsNullOrEmpty(p.Color) && p.Color.ToLower().Contains(color.ToLower()));
            }
            if (!string.IsNullOrEmpty(origin))
            {
                query = query.Where(p => !string.IsNullOrEmpty(p.Origin) && p.Origin.ToLower().Contains(origin.ToLower()));
            }
            if (!string.IsNullOrEmpty(caratWeight))
            {
                query = query.Where(p => !string.IsNullOrEmpty(p.CaratWeight) && p.CaratWeight.ToLower().Contains(caratWeight.ToLower()));
            }
            if (!string.IsNullOrEmpty(clarity))
            {
                query = query.Where(p => !string.IsNullOrEmpty(p.Clarity) && p.Clarity.ToLower().Contains(clarity.ToLower()));
            }
            if (!string.IsNullOrEmpty(cut))
            {
                query = query.Where(p => !string.IsNullOrEmpty(p.Cut) && p.Cut.ToLower().Contains(cut.ToLower()));
            }
            return query;
        }
    }
}