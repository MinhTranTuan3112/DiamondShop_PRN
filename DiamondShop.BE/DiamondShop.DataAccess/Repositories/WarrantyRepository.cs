using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.DTOs.Warranty;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.DataAccess.Repositories
{
    public class WarrantyRepository : GenericRepository<Warranty>, IWarrantyRepository
    {
        private readonly FlashyCarbonDbContext _context;
        public WarrantyRepository(FlashyCarbonDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Warranty?> GetWarranty_Include_OrderDetail_Product(Guid warrantyId)
        {
            return await _context.Warranties
                .Include(war => war.OrderDetail).ThenInclude(od => od.Product)
                .Include(war => war.OrderDetail).ThenInclude(od => od.Diamond)
                .FirstOrDefaultAsync(war => war.Id == warrantyId);
        }

        public async Task<PagedResult<Warranty>?> GetFilteredListAsync(WarrantyFilterDto input)
        {
            var query = _context.Warranties
                .Include(war => war.OrderDetail).ThenInclude(odtl => odtl.Order).ThenInclude(war => war.Customer)
                .AsNoTracking()
                .AsSplitQuery()
                .AsQueryable();

            //=========================[ APPLY FILTER]=========================
            //Customer name
            if (!string.IsNullOrEmpty(input.CustomerName))
            {
                query = query.Where(war => war.OrderDetail.Order.Customer.Fullname.ToLower().Contains(input.CustomerName.ToLower()));
            }
            //Customer phone
            if (!string.IsNullOrEmpty(input.CustomerPhone))
            {
                query = query.Where(war => war.OrderDetail.Order.Customer.PhoneNumber.Equals(input.CustomerPhone));
            }

            //Item name
            if (!string.IsNullOrEmpty(input.ItemName))
            {
                query = query.Where(war => war.ItemName.ToLower().Contains(input.ItemName.ToLower()));
            }

            //Is Product Or Diamond
            if (input.IsProduct is not null)
            {
                query = query.Where(war => war.IsProduct == input.IsProduct);
            }

            //Follow by type
            string[] inputTypeArray = input.Type.ToString().ToLower().Split(',');
            query = query.Where(war => inputTypeArray.Any(inty => war.Type.ToLower().Contains(inty)));

            //In date range
            if (input.StartDate.HasValue)
            {
                query = query.Where(war => war.StartDate >= input.StartDate.Value);
            }

            if (input.EndDate.HasValue)
            {
                query = query.Where(war => war.EndDate <= input.EndDate.Value);
            }

            //By Status
            query = query.Where(war => war.Status.ToLower().Equals(input.Status.ToString().ToLower()));

            //Sort By Time
            query = (input.IsDescending == true) ?
                query.OrderByDescending(war => war.StartDate) : query.OrderBy(war => war.StartDate);

            int amountItem = input.Size == 0 ? 10 : input.Size;
            int pageIndex = input.Page == 0 ? 1 : input.Page;

            // Apply paging
            var queriedOrders = await query
                .Skip((pageIndex - 1) * amountItem)
                .Take(amountItem)
                .ToListAsync();

            return new PagedResult<Warranty>
            {
                Results = queriedOrders,
                TotalCount = await query.CountAsync(),
                PageSize = amountItem,
                CurrentPage = pageIndex
            };
        }
    }
}
