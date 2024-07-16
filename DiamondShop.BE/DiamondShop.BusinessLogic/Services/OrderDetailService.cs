using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.DTOs.OrderDetail;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Mapster;
using Newtonsoft.Json;

namespace DiamondShop.BusinessLogic.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAddDiamondToCart(Order order, AddToCartDto addToCartDto)
        {
            var diamondId = addToCartDto.DiamondId;
            var diamond = await _unitOfWork.GetDiamondRepository().FindOneAsync(d => d.Id == diamondId);

            if (diamond is null)
            {
                throw new NotFoundException($"Can't find any diamonds with id {diamondId}");
            }

            addToCartDto.RingSize = null;
            addToCartDto.SumSizePrice = 0;

            var orderDetail = order.OrderDetails.FirstOrDefault(od => od.DiamondId == diamondId);

            if (orderDetail is null)
            {
                orderDetail = await _unitOfWork.GetOrderDetailRepository().AddAsync(new OrderDetail
                {
                    OrderId = order.Id,
                    DiamondId = diamond.Id
                });

                await _unitOfWork.SaveChangesAsync();
            }

            orderDetail.Quantity += addToCartDto.Quantity;
            orderDetail.SubTotal += diamond.Price * orderDetail.Quantity;
            order.Total += orderDetail.SubTotal;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task HandleAddProductToCart(Order order, AddToCartDto addToCartDto)
        {
            var product = await _unitOfWork.GetProductRepository().FindOneAsync(p => p.Id == addToCartDto.ProductId);

            if (product is null)
            {
                throw new NotFoundException($"Can't find any products with id {addToCartDto.ProductId}");
            }

            var orderDetail = order.OrderDetails.FirstOrDefault(od => od.ProductId == addToCartDto.ProductId);

            if (orderDetail is null)
            {
                orderDetail = await _unitOfWork.GetOrderDetailRepository().AddAsync(new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = product.Id
                });

                await _unitOfWork.SaveChangesAsync();
            }

            if (product.Type == ProductType.Ring.ToString())
            {
                var ringSizes = (orderDetail.RingSize is null)
                                ? []
                                : JsonConvert.DeserializeObject<List<RingSizeDto>>(orderDetail.RingSize);

                var ringSize = ringSizes?.FirstOrDefault(rs => rs.Size == addToCartDto.RingSize);
                if (ringSize is null)
                {
                    ringSizes?.Add(new RingSizeDto
                    {
                        Size = addToCartDto.RingSize is null ? 0 : Convert.ToInt32(addToCartDto.RingSize),
                        Quantity = addToCartDto.Quantity
                    });
                }
                else
                {
                    ringSize.Quantity += addToCartDto.Quantity;
                }

                orderDetail.RingSize = JsonConvert.SerializeObject(ringSizes);
                orderDetail.SumSizePrice += addToCartDto.SumSizePrice;
            }
            else
            {
                orderDetail.RingSize = null;
                orderDetail.SumSizePrice = 0;
            }


            orderDetail.Quantity += addToCartDto.Quantity;
            orderDetail.SubTotal += product.Price * orderDetail.Quantity + orderDetail.SumSizePrice;
            order.Total += orderDetail.SubTotal;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<OrderDetail> Get_OrderDetail_By_Id(Guid id)
        {
            var existOrderDetail = await _unitOfWork.GetOrderDetailRepository().GetByIdAsync(id)
                ?? throw new NotFoundException("Not found any order detail match the id!");
            return existOrderDetail;
        }

        public async Task<OrderDetail> Get_OrderDetail_IncludeReference(Guid orderDetailId)
        {
            var existOrderDetail = await _unitOfWork.GetOrderDetailRepository().GetById_IncludeReference(orderDetailId)
                ?? throw new NotFoundException("Not found any order detail match the id!");
            return existOrderDetail;
        }

        public async Task<List<OrderDetail>> GetList_OrderDetail_By_OrderId(Guid orderId)
        {
            var listOrderDetail = await _unitOfWork.GetOrderDetailRepository().GetListOrderDetailfromOrderId(orderId)
                ?? throw new NotFoundException("Not found any order detail of that order!");
            return listOrderDetail;
        }
        public async Task<PagedResult<OrderDetail>> GetList_OrderDetail_By_Filter(OrderDetail_PagingDto filters)
        {
            var listOrderDetail = await _unitOfWork.GetOrderDetailRepository().GetListOrderDetailByFilter(filters)
                ?? throw new NotFoundException("Not found any order detail of that order!");
            return listOrderDetail;
        }
        public async Task<bool> UpdateOrderDetail(OrderDetail_InfoDto updatedOrderDetail)
        {
            var foundOrderDetail = await _unitOfWork.GetOrderDetailRepository().GetByIdAsync(updatedOrderDetail.OrderDetailId)
                ?? throw new NotFoundException("Not found any order detail of that order!");

            //Mapster auto map
            updatedOrderDetail.Adapt(foundOrderDetail);

            return await _unitOfWork.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteOrderDetail(Guid orderDetailId)
        {
            var foundOrderDetail = await _unitOfWork.GetOrderDetailRepository().GetByIdAsync(orderDetailId)
                ?? throw new NotFoundException("Not found any order detail of that order!");
            return await _unitOfWork.GetOrderDetailRepository().DeleteOrderDetailAndReferences(foundOrderDetail);
        }
    }
}