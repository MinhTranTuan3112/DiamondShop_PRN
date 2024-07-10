using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Warranty;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.Shared.Exceptions;
using DiamondShop.DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using DiamondShop.DataAccess.Enums;

namespace DiamondShop.BusinessLogic.Services
{
    public class WarrantyService : IWarrantyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarrantyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Warranty> GetDetailAsync(Guid id)
        {
            var warranty = await _unitOfWork.GetWarrantyRepository().GetByIdAsync(id)
                ?? throw new BadRequestException("Not found that warranty Id");
            return warranty;
        }

        public async Task<IEnumerable<Warranty>> GetWarranties_Of_OrderDetail(Guid orderDetailId)
        {
            var warranties = await _unitOfWork.GetWarrantyRepository().FindAsync(war => war.OrderDetailId == orderDetailId)
                ?? throw new BadRequestException("Not found any warranty of that order detail id");
            return warranties;
        }

        //public async Task<IEnumerable<Warranty>> ViewListOfWarranty(WarrantyFilterDto filtered)
        //{
        //    var warranty = await _unitOfWork.GetWarrantyRepository().
        //        ?? throw new BadRequestException("Not found that warranty Id");
        //    return warranty;
        //}

        public async Task<bool> CreateWarranty(WarrantyNewDto warrantyNew)
        {
            string warrantyType_input = warrantyNew.Type.ToString(),
                comprehensiveType = WarrantyType.Comprehensive.ToString(),
                FinalProductName = "",
                FinalDiamondName = "",
                FinalType;

            //Get Order Detail
            var orderDetail_exist = await _unitOfWork.GetOrderDetailRepository().GetById_IncludeReference(warrantyNew.OrderDetailId)
                ?? throw new NotFoundException("Not found order detail for creating warranty!");

            //Get Product Diamond Name in orderDetail
            var product_exist = await _unitOfWork.GetProductRepository().GetByIdAsync(orderDetail_exist.ProductId ?? Guid.Empty);
            var diamond_exist = await _unitOfWork.GetDiamondRepository().GetByIdAsync(orderDetail_exist.DiamondId ?? Guid.Empty);

            //Assign Finaltype = Comprehensive || Types in list inputTypes || ""
            FinalType = warrantyType_input.ToLower().Equals(comprehensiveType.ToLower()) ?
                comprehensiveType : ExtractTypes(warrantyType_input);

            if (product_exist is not null)
            {
                //Assign name of product
                FinalProductName += product_exist.Name ?? "Empty Product Name";

                //If product combine with diamond => assign diamond name into product
                if (orderDetail_exist.ComplexProduction == true)
                {
                    FinalProductName += " - " + MergedNameOf_MultipleDiamond(product_exist.Id);
                }

                await _unitOfWork.GetWarrantyRepository().AddAsync(
                new Warranty
                {
                    OrderDetailId = orderDetail_exist.OrderId,
                    ItemName = FinalProductName,
                    Type = FinalType,
                    Privacy = warrantyNew.Privacy,
                    Condition = warrantyNew.Condition,
                    IsProduct = true,
                    StartDate = DateTime.Now,
                    Reason = warrantyNew.Reason,
                    Status = WarrantyStatus.Temporary.ToString()
                });
            }

            if (diamond_exist is not null)
            {
                FinalDiamondName += diamond_exist.Name ?? "Empty Diamond Name";

                await _unitOfWork.GetWarrantyRepository().AddAsync(
                    new Warranty
                    {
                        OrderDetailId = orderDetail_exist.OrderId,
                        ItemName = FinalDiamondName,
                        Type = FinalType,
                        Privacy = warrantyNew.Privacy,
                        Condition = warrantyNew.Condition,
                        IsProduct = false,
                        StartDate = DateTime.Now,
                        Reason = warrantyNew.Reason,
                        Status = WarrantyStatus.Temporary.ToString()
                    });
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        private async Task<string> MergedNameOf_MultipleDiamond(Guid productId)
        {
            var complexProduct = await _unitOfWork.GetProductPartRepository().FindAsync(prodia => prodia.ProductId == productId);
            if (complexProduct is null) return "";

            string MergedName = "";
            foreach (var eachItem in complexProduct)
            {
                var eachDiamond = await _unitOfWork.GetDiamondRepository().GetByIdAsync(eachItem.DiamondId);
                MergedName += eachDiamond is not null ? eachDiamond.Name + "|" : "";
            }
            return MergedName;
        }
        private static string ExtractTypes(string type)
        {
            //Convert to list
            var typeList = new List<string>();

            int startIndex = type.IndexOf('[') + 1;
            int endIndex = type.IndexOf(']');

            if (startIndex > 0 && endIndex > startIndex)
            {
                return type.Substring(startIndex, endIndex - startIndex);
            }
            return "";
        }
    }
}
