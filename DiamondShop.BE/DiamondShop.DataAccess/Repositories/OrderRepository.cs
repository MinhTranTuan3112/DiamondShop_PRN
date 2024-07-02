using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly FlashyCarbonDbContext _context;
        public OrderRepository(FlashyCarbonDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Order?> GetOrderWithOrderDetails(Expression<Func<Order, bool>> predicate)
        {
            return _context.Orders.Include(o => o.OrderDetails)
                                 .FirstOrDefaultAsync(predicate);
        }

        public async Task<Order?> GetOrderById (Guid id, bool includeDetail)
        {
            if (includeDetail)
            {
                return await _context.Orders
                    .Include(ord => ord.OrderDetails)
                    .FirstOrDefaultAsync(ord => ord.Id == id);
            }
            return await _context.Orders.FindAsync(id);
        }
    }
}