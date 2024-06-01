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

            if (product.Type != ProductType.Ring.ToString())
            {
                addToCartDto.RingSize = 0;
                addToCartDto.RingSizePrice = 0;
            }

            var accountId = claims.GetAccountId();
            var customer = await _unitOfWork.GetCustomerRepository().FindOneAsync(c => c.AccountId == accountId);

            if (customer is null)
            {
                throw new BadRequestException("No customer found");
            }


            var order = await _unitOfWork.GetOrderRepository().GetOrderWithOrderDetails(o => o.CustomerId == customer.Id 
            && o.Status == OrderStatus.InCart.ToString());

            if (order is null)
            {
                order = await _unitOfWork.GetOrderRepository().AddAsync(new Order
                {
                    CustomerId = customer.Id,
                    Status = OrderStatus.InCart.ToString()
                });

                await _unitOfWork.SaveChangesAsync();
            }

            var orderDetail = order.OrderDetails.FirstOrDefault(od => od.ProductId == addToCartDto.ProductId
            && od.RingSize == addToCartDto.RingSize);

            if (orderDetail is null)
            {
                decimal subTotal = product.Price * addToCartDto.Quantity + addToCartDto.RingSizePrice;

                await _unitOfWork.GetOrderDetailRepository().AddAsync(new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = addToCartDto.Quantity,
                    RingSize = addToCartDto.RingSize,
                    RingSizePrice = addToCartDto.RingSizePrice,
                    SubTotal = subTotal
                });

                order.Total += subTotal;
            }
            else
            {
                orderDetail.Quantity += addToCartDto.Quantity;
                orderDetail.SubTotal = orderDetail.Quantity * product.Price + orderDetail.RingSizePrice;
                order.Total += orderDetail.SubTotal;
            }


            await _unitOfWork.SaveChangesAsync();

        }


    }
}