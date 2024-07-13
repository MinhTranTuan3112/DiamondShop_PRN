using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Warranty;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.Shared.Exceptions;
using DiamondShop.DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using DiamondShop.DataAccess.Enums;
using System.Text;
using System.Text.RegularExpressions;
using DiamondShop.DataAccess.DTOs.Query;

namespace DiamondShop.BusinessLogic.Services
{
    public class WarrantyService : IWarrantyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static string FullComboType = WarrantyType.Comprehensive.ToString();
        private static string DefaulStatus = WarrantyStatus.Temporary.ToString();

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

        public async Task<IEnumerable<Warranty>> GetWarranties_Of_OrderDetailAsync(Guid orderDetailId)
        {
            var warranties = await _unitOfWork.GetWarrantyRepository().FindAsync(war => war.OrderDetailId == orderDetailId)
                ?? throw new BadRequestException("Not found any warranty of that order detail id");
            return warranties;
        }

        public async Task<PagedResult<Warranty>> GetFiltered_List_WarrantyAsync(WarrantyFilterDto filtered)
        {
            //Validate Phone Number
            if (!string.IsNullOrEmpty(filtered.CustomerPhone)) ValidatePhoneNumber(filtered.CustomerPhone);

            //Then query list
            var warranty = await _unitOfWork.GetWarrantyRepository().GetFilteredListAsync(filtered)
                ?? throw new BadRequestException("Not found that warranty Id");
            return warranty;
        }

        public async Task<bool> CreateWarrantyAsync(WarrantyNewDto warrantyNew)
        {
            string warrantyType_input = warrantyNew.Type.ToString(),
                productName = "Unknown Name",
                diamondName = "Unknown Name";
            bool IsForProduct_Flag = false;

            //Get type for each one = Comprehensive || Types in regex Product[abc,xyz] - Diamond[ABC,XYZ]
            (string product, string diamond) WarrantyTypeOf = ExtractTypes(warrantyType_input);

            //Get Order Detail
            var orderDetail_exist = await _unitOfWork.GetOrderDetailRepository().GetById_IncludeReference(warrantyNew.OrderDetailId)
                ?? throw new NotFoundException("Not found order detail for creating warranty!");

            //Get Product/Diamond in orderDetail
            var product_exist = await _unitOfWork.GetProductRepository().GetByIdAsync(orderDetail_exist.ProductId ?? Guid.Empty);
            var diamond_exist = await _unitOfWork.GetDiamondRepository().GetByIdAsync(orderDetail_exist.DiamondId ?? Guid.Empty);

            //Save name of product if available
            if (product_exist is not null)
            {
                IsForProduct_Flag = true;
                productName = product_exist.Name;
            }
            //Save name of diamond if available
            if (diamond_exist is not null)
            {
                IsForProduct_Flag = false;
                diamondName = $"{diamond_exist.Origin} {diamond_exist.Shape} {diamond_exist.Color} {diamond_exist.Clarity} {diamond_exist.Cut} {diamond_exist.CaratWeight}";
            }

            //If 1 OrderDetail  have Product mixed Diamond => create 2 warranties of 1 order detail
            if (orderDetail_exist.ComplexProduction == true)
            {
                diamondName = await MergedNameOf_MultipleDiamond(product_exist!.Id);
                await _unitOfWork.GetWarrantyRepository().AddRangeAsync([
                    new Warranty
                    {
                        OrderDetailId = orderDetail_exist.OrderId,
                        ItemName = productName,
                        Type = WarrantyTypeOf.product,
                        Privacy = warrantyNew.Privacy,
                        Condition = warrantyNew.Condition,
                        IsProduct = true,
                        StartDate = DateTime.Now,
                        Reason = warrantyNew.Reason,
                        Status = DefaulStatus
                    },
                    new Warranty
                    {
                        OrderDetailId = orderDetail_exist.OrderId,
                        ItemName = diamondName,
                        Type = WarrantyTypeOf.diamond,
                        Privacy = warrantyNew.Privacy,
                        Condition = warrantyNew.Condition,
                        IsProduct = false,
                        StartDate = DateTime.Now,
                        Reason = warrantyNew.Reason,
                        Status = DefaulStatus
                    }
                ]);
            }
            else
            {
                await _unitOfWork.GetWarrantyRepository().AddAsync(
                    new Warranty
                    {
                        OrderDetailId = orderDetail_exist.OrderId,
                        ItemName = IsForProduct_Flag ? productName : diamondName,
                        Type = WarrantyTypeOf.diamond,
                        Privacy = warrantyNew.Privacy,
                        Condition = warrantyNew.Condition,
                        IsProduct = IsForProduct_Flag,
                        StartDate = DateTime.Now,
                        Reason = warrantyNew.Reason,
                        Status = DefaulStatus
                    });
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateWarrantyAsync(WarrantyUpdateDto warranty_input)
        {
            int syncMonth;
            string syncName="";
            bool isComplex=false;

            //Validate before query
            if (warranty_input.Id == Guid.Empty) throw new BadRequestException("Invalid warranty Id to find");

            if (!string.IsNullOrEmpty(warranty_input.Type))
            {
                ValidateWarrantyType(warranty_input.Type);
            }

            //Find warranty with its relevant
            var warranty_Obj = await _unitOfWork.GetWarrantyRepository().GetWarranty_Include_OrderDetail_Product(warranty_input.Id)
                ?? throw new NotFoundException("Not found any warranty suitable the given Id");
            var orderDetail_Obj = warranty_Obj.OrderDetail;
            var product_Obj = orderDetail_Obj.Product;
            var diamond_Obj = orderDetail_Obj.Diamond;

            //Complex? syncName = All diamond in product Name
            if (orderDetail_Obj.ComplexProduction == true)
            {
                isComplex = true;
                syncName = product_Obj is not null ? await MergedNameOf_MultipleDiamond(product_Obj.Id) : "Error merged diamond name";
            }

            //Sync "Name,Warranty Period" from "Product/Diamond"
            if (warranty_Obj.IsProduct == true)
            {
                if (product_Obj is null) throw new NotFoundException("Cannot found product of this warranty!");

                syncName = product_Obj.Name ?? "Empty Product Name";
                syncMonth = product_Obj.WarrantyPeriod;
            }
            else
            {
                if (diamond_Obj is null) throw new NotFoundException("Cannot found diamond of this warranty!");

                //Single Diamond
                if (isComplex == false)
                {
                    syncName = $"{diamond_Obj.Origin} {diamond_Obj.Shape} {diamond_Obj.Color} {diamond_Obj.Clarity} {diamond_Obj.Cut} {diamond_Obj.CaratWeight}";
                }
                syncMonth = diamond_Obj.WarrantyPeriod;
            }

            //Sync with product/diamond
            warranty_Obj.ItemName = syncName;
            warranty_Obj.StartDate = warranty_input.StartDate;
            warranty_Obj.EndDate = warranty_input.StartDate.AddMonths(syncMonth);

            //From client sent
            warranty_Obj.Type = warranty_input.Type;
            warranty_Obj.Privacy = warranty_input.Privacy;
            warranty_Obj.Condition = warranty_input.Condition;
            warranty_Obj.Reason = warranty_input.Reason;

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> ChangeStatus(Guid warrantyId, WarrantyStatus enumStatus)
        {
            int productPeriod = 0, diamondPeriod = 0, warrantyPeriod;
            string newStatus = enumStatus.ToString();
            Warranty? warranty_Obj = null;

            //Validate Status
            if (!Enum.IsDefined(typeof(WarrantyStatus), newStatus))
                throw new BadRequestException("Not valid status to be change!");

            if (newStatus.ToLower().Equals(WarrantyStatus.Availability.ToString().ToLower()))
            {
                warranty_Obj = await _unitOfWork.GetWarrantyRepository().GetWarranty_Include_OrderDetail_Product(warrantyId)
                ?? throw new NotFoundException("Not found any warranty suitable the given Id");
                var product_Obj = warranty_Obj.OrderDetail.Product;
                var diamond_Obj = warranty_Obj.OrderDetail.Diamond;

                if (product_Obj is not null) productPeriod = product_Obj.WarrantyPeriod;
                if (diamond_Obj is not null) diamondPeriod = diamond_Obj.WarrantyPeriod;

                //Assign time base on product or diamond
                warrantyPeriod = warranty_Obj.IsProduct == true ? productPeriod : diamondPeriod;

                //Update Time
                warranty_Obj.StartDate = DateTime.Now;
                warranty_Obj.EndDate = DateTime.Now.AddMonths(warrantyPeriod);
            }
            else
            {
                //Validate warrantyId
                warranty_Obj = await _unitOfWork.GetWarrantyRepository().GetByIdAsync(warrantyId)
                    ?? throw new NotFoundException("Not found this Warranty");

                //Validate Status
                if (warranty_Obj.Status.ToLower().Equals(newStatus.ToLower()))
                    throw new BadRequestException("New status is same as previous status!");
            }

            //Then change Status
            warranty_Obj.Status = newStatus;

            //Save Change
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteWarrantyAsync(Guid id)
        {
            var existWarranty = await _unitOfWork.GetWarrantyRepository().GetByIdAsync(id)
                ?? throw new NotFoundException("Not found that warranty to delete!");
            if (existWarranty.Status.ToLower().Equals(WarrantyStatus.Deleted.ToString().ToLower()))
                throw new BadRequestException("This warranty have already deleted!");

            existWarranty.Status = WarrantyStatus.Deleted.ToString();
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        private static void ValidateWarrantyType(string type)
        {
            if (!Enum.IsDefined(typeof(WarrantyType), type))
                throw new BadRequestException("Not a valid type of warranty!");
        }
        private static void ValidatePhoneNumber(string? phoneNumber)
        {
            string pattern = @"^\+?[1-9]{1}[0-9]{1,14}$";

            // Check if the phone number matches the pattern
            if (Regex.IsMatch(phoneNumber, pattern)) throw new BadRequestException("Wrong Input Format Phone Number!");
        }

        private async Task<string> MergedNameOf_MultipleDiamond(Guid productId)
        {
            var complexProduct = await _unitOfWork.GetProductPartRepository().FindAsync(prodia => prodia.ProductId == productId);
            if (complexProduct is null) return "";

            var MergedName = new StringBuilder(); ;
            foreach (var eachItem in complexProduct)
            {
                var eachDiamond = await _unitOfWork.GetDiamondRepository().GetByIdAsync(eachItem.DiamondId);
                if (eachDiamond is null) continue;
                MergedName.AppendFormat("{0} {1} {2} {3} {4} |",
                    eachDiamond.Shape,
                    eachDiamond.Color,
                    eachDiamond.Clarity,
                    eachDiamond.Cut,
                    eachDiamond.CaratWeight);
            }

            if (MergedName.Length > 0)
            {
                MergedName.Length--; // Remove the last "|"
            }
            return MergedName.ToString();
        }
        private static (string, string) ExtractTypes(string typeInput)
        {

            if (typeInput.ToLower().Equals(FullComboType.ToLower())) return (FullComboType, FullComboType);

            var productPattern = @"Product\[(.*?)\]";
            var diamondPattern = @"Diamond\[(.*?)\]";

            var productMatch = Regex.Match(typeInput, productPattern);
            var diamondMatch = Regex.Match(typeInput, diamondPattern);

            //Handle if error or not
            string productType_Values = productMatch.Success ? productMatch.Groups[1].Value : string.Empty;
            string diamondType_Values = diamondMatch.Success ? diamondMatch.Groups[1].Value : string.Empty;

            return (productType_Values, diamondType_Values);
        }
    }
}
