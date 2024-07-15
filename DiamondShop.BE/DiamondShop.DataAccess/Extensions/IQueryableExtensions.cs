using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.DTOs.Certificate;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
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
            // var name = queryDiamondDto.Name;
            var colors = queryDiamondDto.Colors;
            var cuts = queryDiamondDto.Cuts;
            var clarities = queryDiamondDto.Clarities;

            if (startPrice < endPrice)
            {
                if (startPrice.HasValue)
                {
                    query = query.Where(d => d.Price >= startPrice);
                }

                if (endPrice.HasValue)
                {
                    query = query.Where(d => d.Price <= endPrice);
                }
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

        public static IQueryable<Certificate> ApplyCertificateFilter(this IQueryable<Certificate> query,
            QueryCertificateDto queryCertificateDto)
        {
            var startDateOfIssue = queryCertificateDto.StartDateOfIssue;
            var endDateOfIssue = queryCertificateDto.EndDateOfIssue;
            var reportNumber = queryCertificateDto.ReportNumber;
            var diamondId = queryCertificateDto.DiamondId;
            if (startDateOfIssue < endDateOfIssue)
            {
                query = query.Where(c => c.DateOfIssue >= startDateOfIssue && c.DateOfIssue <= endDateOfIssue);
            }

            if (!string.IsNullOrEmpty(reportNumber))
            {
                query = query.Where(c => !string.IsNullOrEmpty(c.ReportNumber) && c.ReportNumber == reportNumber);
            }

            if (diamondId is not null)
            {
                query = query.Where(c => c.Diamond != null && c.Diamond.Id == diamondId);
            }

            return query;
        }

        public static IQueryable<Account> ApplyAccountFilter(this IQueryable<Account> query,
            QueryAccountDto queryAccountDto)
        {
            var role = queryAccountDto.Role;
            var email = queryAccountDto.Email;
            var fullName = queryAccountDto.FullName;
            if (role is not null)
            {
                query = role switch
                {
                    Role.Customer => query.Where(a => a.Role == Role.Customer.ToString().ToLower()),
                    Role.Admin => query.Where(a => a.Role == Role.Admin.ToString().ToLower()),
                    Role.Manager => query.Where(a => a.Role == Role.Manager.ToString().ToLower()),
                    Role.DeliveryStaff => query.Where(a => a.Role == Role.DeliveryStaff.ToString().ToLower()),
                    Role.SalesStaff => query.Where(a => a.Role == Role.SalesStaff.ToString().ToLower()),
                    _ => query
                };
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(a => !string.IsNullOrEmpty(a.Email) && a.Email == email);
            }

            if (!string.IsNullOrEmpty(fullName))
            {
                query = query.Where(a =>
                    (!string.IsNullOrEmpty(a.Customer.Fullname) && a.Customer.Fullname.ToLower().Contains(fullName)) ||
                    (!string.IsNullOrEmpty(a.StakeHolder.Fullname) && a.StakeHolder.Fullname.ToLower().Contains(fullName)));
            }

            return query;
        }
    }
}