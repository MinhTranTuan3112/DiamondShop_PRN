using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.DataAccess.Repositories
{
    public class PictureRepository : GenericRepository<Picture>, IPictureRepository
    {
        private readonly FlashyCarbonDbContext _dbContext;

        public PictureRepository(FlashyCarbonDbContext context) : base(context)
        {
            this._dbContext = context;
        }

       
    }
}
