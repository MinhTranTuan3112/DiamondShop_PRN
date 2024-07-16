using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Account;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Extensions;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly FlashyCarbonDbContext _context;
        public AccountRepository(FlashyCarbonDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Account?> GetAccountDetail(Guid id)
        {
            return await _context.Accounts.Include(x => x.Customer)
                                          .Include(x => x.StakeHolder)
                                          .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResult<Account>> GetPagedAccount(QueryAccountDto queryAccountDto)
        {
            var pageNumber = queryAccountDto.PageNumber;
            var pageSize = queryAccountDto.PageSize;
            var sortBy = queryAccountDto.SortColumn;
            var orderByDesc = queryAccountDto.OrderByDesc;
            var query = _context.Accounts.AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.StakeHolder).AsSplitQuery().AsQueryable();
            query = query.ApplyAccountFilter(queryAccountDto);
            query = orderByDesc
                ? query.OrderByDescending(GetSortProperty(sortBy))
                : query.OrderBy(GetSortProperty(sortBy));
            query = query.Where(a => a.Status != "deleted");
            return await query.ToPaginationResultAsync(pageNumber, pageSize);
        }
        private Expression<Func<Account, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "fullname" => a => (a.Customer != null ? a.Customer.Fullname : (a.StakeHolder.Fullname)),
                "email" => a => a.Email != null ? a.Email : a.Id,
                "createdTime" => a => a.CreatedTime != null ? a.CreatedTime : a.Id,
                _ => a => a.Id
            };
        }
    }
}