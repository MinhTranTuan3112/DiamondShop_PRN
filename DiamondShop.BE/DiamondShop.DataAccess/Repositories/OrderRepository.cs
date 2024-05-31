using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;

namespace DiamondShop.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(FlashyCarbonDbContext context) : base(context)
        {
        }
    }
}