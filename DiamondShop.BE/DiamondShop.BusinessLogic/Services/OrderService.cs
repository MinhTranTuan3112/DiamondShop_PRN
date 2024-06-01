using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DiamondShop.BusinessLogic.Extensions;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DiamondShop.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddToCart(AddToCartDto addToCartDto, ClaimsPrincipal claims)
        {
            var product = await _unitOfWork.GetProductRepository().FindOneAsync(p => p.Id == addToCartDto.ProductId);

            if (product is null)
            {
                throw new NotFoundException($"Can't find any products with id {addToCartDto.ProductId}");
            }

            var accountId = claims.GetAccountId();
            var customer = await _unitOfWork.GetCustomerRepository().FindOneAsync(c => c.AccountId == accountId);

            if (customer is null)
            {
                throw new BadRequestException("No customer found");
            }

            var order = await GetOrCreateCustomerOrderWithOrderStatus(customer, OrderStatus.InCart);

            //TODO: Order detail logic here
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

        private async Task<Order> GetOrCreateCustomerOrderWithOrderStatus(Customer customer, OrderStatus orderStatus)
        {
            var order = await _unitOfWork.GetOrderRepository().GetOrderWithOrderDetails(o => o.CustomerId == customer.Id
                        && o.Status == orderStatus.ToString());

            if (order is null)
            {
                order = await _unitOfWork.GetOrderRepository().AddAsync(new Order
                {
                    CustomerId = customer.Id,
                    Status = orderStatus.ToString()
                });

                await _unitOfWork.SaveChangesAsync();
            }

            return order;
        }
    }
}