using DiamondShop.DataAccess.DTOs.Diamond;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.DTOs.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IDiamondService
    {
        Task<PagedResult<GetDiamondInPageResultDto>> GetPageDiamonds(QueryDiamondDto queryDiamondDto);

        Task<GetDiamondIdDto> CreateDiamond(CreateDiamondDto createDiamondDto);

        Task UpdateDiamond(Guid id, UpdateDiamondDto updateDiamondDto);

    }
}
