using DiamondShop.DataAccess.DTOs.OrderDetail;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly FlashyCarbonDbContext _context;
        public OrderDetailRepository(FlashyCarbonDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>> GetListOrderDetailByFilter(OrderDetail_InfoDto filters)
        {
            var query = _context.OrderDetails
                .AsNoTracking()
                .AsSplitQuery()
                .AsQueryable();

            // Apply search
            if (filters.OrderId != Guid.Empty) query = query.Where(odtl => odtl.OrderId == filters.OrderId);
            if (filters.ProductId != Guid.Empty) query = query.Where(odtl => odtl.ProductId == filters.ProductId);
            if (filters.DiamondId != Guid.Empty) query = query.Where(odtl => odtl.DiamondId == filters.DiamondId);
            if (filters.ComplexProduction is not null) query = query.Where(odtl => odtl.DiamondId == filters.DiamondId);
            if (filters.Quantity != 0) query = query.Where(odtl => odtl.Quantity == filters.Quantity);
            //if (filters.RingSize is not null) query = query.Where(odtl => odtl.RingSize == filters.RingSize);
            if (filters.SumSizePrice != 0) query = query.Where(odtl => odtl.SumSizePrice == filters.SumSizePrice);
            if (filters.SubTotal != 0) query = query.Where(odtl => odtl.SubTotal == filters.SubTotal);

            query = query.OrderByDescending(odtl => odtl.SubTotal);

            int amountItem = filters.Size == 0 ? 5 : filters.Size;
            int pageIndex = filters.Page == 0 ? 1 : filters.Page;

            // Apply paging
            var queriedOrderDetails = await query
                .Skip((pageIndex - 1) * amountItem)
                .Take(amountItem)
                .ToListAsync();

            return queriedOrderDetails;
        }
    }
}