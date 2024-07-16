using System.Linq.Expressions;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<PagedResult<Order>?> GetListAsync(QueryOrderDto input)
        {
            var query = _context.Orders
                .AsNoTracking()
                .AsSplitQuery()
                .AsQueryable();

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
            if (!input.PayMethod.IsNullOrEmpty())
            {
                query = query.Where(ord => ord.PayMethod.ToLower().Contains(input.PayMethod!.ToLower()));
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
                query = query.Where(ord => ord.Status.ToLower().Equals(input.Status!.ToLower()));
            }

            // Sort
            if(input.OrderByCode == true)
            {
                query = input.IsDescendingCode ?query.OrderByDescending(ord => ord.Code) : query.OrderBy(ord => ord.Code);
            } else
            {
                query = input.IsDescendingDate? query.OrderByDescending(ord => ord.OrderDate) : query.OrderBy(ord => ord.OrderDate);
            }

            int amountItem = input.Size == 0 ? 5 : input.Size;
            int pageIndex = input.Page == 0 ? 1 : input.Page;

            // Apply paging
            var queriedOrders = await query
                .Skip((pageIndex - 1) * amountItem)
                .Take(amountItem)
                .ToListAsync();

            return new PagedResult<Order>
            {
                Results = queriedOrders,
                TotalCount = await query.CountAsync(),
                PageSize = amountItem,
                CurrentPage = pageIndex
            };
        }

        public async Task<Order?> GetCustomerCartInfo(Guid customerId)
        {
            return await _context.Orders.AsNoTracking()
                                        .Where(o => o.CustomerId == customerId && o.Status == OrderStatus.InCart.ToString())
                                        .Include(o => o.OrderDetails)
                                        .ThenInclude(od => od.Diamond)
                                        .Include(o => o.OrderDetails)
                                        .ThenInclude(od => od.Product)
                                        .AsSplitQuery()
                                        .FirstOrDefaultAsync();
        }

        public async Task<Order?> GetOrderWithDetailsCustomerInfo(Guid orderId)
        {
            return await _context.Orders
                                    .Include(o => o.OrderDetails)
                                    .ThenInclude(od => od.Product)
                                    .Include(o => o.OrderDetails)
                                    .ThenInclude(od => od.Diamond)
                                    .Include(o => o.Customer)
                                    .ThenInclude(c => c.Account)
                                    .AsSplitQuery()
                                    .SingleOrDefaultAsync(o => o.Id == orderId);
        }
    }
}