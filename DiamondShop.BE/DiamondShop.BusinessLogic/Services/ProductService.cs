using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Product;
using DiamondShop.DataAccess.Interfaces;
using Mapster;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<ViewProductDTO>> GetProductAsync(Guid id)
        {
            var _response = new ServiceResponse<ViewProductDTO>();
            try
            {
                var product = await _unitOfWork.GetProductRepository().GetProductById(id);
                if (product != null)
                {
                    _response.Success = true;
                    _response.Message = "Product retrieved successfully";
                    _response.Data = product.Adapt<ViewProductDTO>();
                }
                else
                {
                    _response.Success = true;
                    _response.Message = "Product not found";
                }
            }
            catch (DbException e)
            {
                _response.Success = false;
                _response.Message = "Database error occured";
                _response.ErrorMessages = new List<string> { e.Message };
            }
            catch (Exception e)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "Error";
                _response.ErrorMessages = new List<string> { e.Message };
            }
            return _response;
        }
    }
}
