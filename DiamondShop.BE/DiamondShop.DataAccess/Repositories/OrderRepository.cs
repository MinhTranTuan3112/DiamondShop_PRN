using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Extensions;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DiamondShop.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly FlashyCarbonDbContext _context;
        public OrderRepository(FlashyCarbonDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Order?> GetOrderWithOrderDetails(Expression<Func<Order, bool>> LINQ_Regex)
        {
            return _context.Orders.Include(o => o.OrderDetails)
                                 .FirstOrDefaultAsync(LINQ_Regex);
        }
        public async Task<IEnumerable<Order>?> GetListAsync(QueryOrderDto input)
        {
            var query = _context.Orders
                .AsNoTracking()
                .AsSplitQuery()
                .AsQueryable();

            query = query.Where(o => o.Status != "Deleted");
            // Apply search
            if (input.SalesStaffId != Guid.Empty)
            {
                query = query.Where(ord => ord.SalesStaffId == input.SalesStaffId);
            }
            if (input.DeliveryStaffId != Guid.Empty)
            {
                query = query.Where(ord => ord.DeliveryStaffId == input.DeliveryStaffId);
            }
            if (!input.Code.IsNullOrEmpty())
            {
                query = query.Where(ord => ord.Code.ToLower().Contains(input.Code!.ToLower()));
            }
            if (!input.ShipAddress.IsNullOrEmpty())
            {
                query = query.Where(ord => ord.ShipAddress.ToLower().Contains(input.ShipAddress!.ToLower()));
            }
            if (!input.Note.IsNullOrEmpty())
            {
                query = query.Where(ord => ord.Note.ToLower().Contains(input.Note!.ToLower()));
            }
            if (!input.Status.IsNullOrEmpty())
            {
                query = query.Where(ord => ord.Code.ToLower().Equals(input.Code!.ToLower()));
            }

            // Sort by code
            query = (input.IsDescending == true) ?
                query.OrderByDescending(ord => ord.Code) : query.OrderBy(ord => ord.Code);

            int amountItem = input.Size == 0 ? 5 : input.Size;
            int pageIndex = input.Page == 0 ? 1 : input.Page;

            // Apply paging
            var queriedOrders = await query
                .Skip((pageIndex - 1) * amountItem)
                .Take(amountItem)
                .ToListAsync();

            return queriedOrders;
        }
    }
}