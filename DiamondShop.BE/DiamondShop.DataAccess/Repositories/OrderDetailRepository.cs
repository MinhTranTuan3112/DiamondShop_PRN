using DiamondShop.DataAccess.DTOs.OrderDetail;
using DiamondShop.DataAccess.DTOs.Query;
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

        public async Task<OrderDetail?> GetById_IncludeReference(Guid orderDetailId)
        {
            return await _context.OrderDetails
                .Include(odtl => odtl.Product)
                .Include(odtl => odtl.Diamond)
                .Include(odtl => odtl.Order)
                .Include(odtl => odtl.Warranties)
                .Include(x => x.Diamond)
                .FirstOrDefaultAsync(odtl => odtl.Id == orderDetailId);
        }

        public async Task<PagedResult<OrderDetail>> GetListOrderDetailByFilter(OrderDetail_PagingDto filters)
        {
            var query = _context.OrderDetails
                .AsNoTracking()
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

            return new PagedResult<OrderDetail>{
                Results = queriedOrderDetails,
                TotalCount = await query.CountAsync(),
                PageSize = amountItem,
                CurrentPage = pageIndex
            };
        }

        public async Task<bool> DeleteOrderDetailAndReferences(OrderDetail? orderDetail)
        {
           if (orderDetail is null) return false;

            //Delete Constrain reference
            await _context.Warranties.Where(waran => waran.OrderDetailId == orderDetail.Id).ExecuteDeleteAsync();

            _context.OrderDetails.Remove(orderDetail);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<IEnumerable<OrderDetail>> GetListOrderDetailfromOrderId(Guid orderid)
        {
            return await _context.OrderDetails
                .Where(odtl => odtl.OrderId == orderid)
                .Include(odtl => odtl.Product)
                .Include(odtl => odtl.Diamond)
                .ToListAsync();
        }
    }
}