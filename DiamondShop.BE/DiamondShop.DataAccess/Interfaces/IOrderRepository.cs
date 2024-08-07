using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOrderWithOrderDetails(Expression<Func<Order, bool>> predicate);
        public Task<PagedResult<Order>?> GetListAsync(QueryOrderDto query);
        Task<Order?> GetCustomerCartInfo(Guid customerId);

        Task<Order?> GetOrderWithDetailsCustomerInfo(Guid orderId);
    }
}