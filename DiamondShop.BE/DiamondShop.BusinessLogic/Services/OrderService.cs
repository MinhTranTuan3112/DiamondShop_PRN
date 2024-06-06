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
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DiamondShop.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceFactory _serviceFactory;

        public OrderService(IUnitOfWork unitOfWork, IServiceFactory serviceFactory)
        {
            _unitOfWork = unitOfWork;
            _serviceFactory = serviceFactory;
        }

        public async Task AddToCart(AddToCartDto addToCartDto, ClaimsPrincipal claims)
        {
            var accountId = claims.GetAccountId();
            var customer = await _unitOfWork.GetCustomerRepository().FindOneAsync(c => c.AccountId == accountId);

            if (customer is null)
            {
                throw new BadRequestException("No customer found");
            }

            var order = await GetOrCreateCustomerOrderWithOrderStatus(customer, OrderStatus.InCart);

            if (addToCartDto is { ProductId: not null, DiamondId: not null })
            {
                throw new BadRequestException("Can't have both ProductId and DiamondId in the same request.");
            }

            //TODO: Order detail logic here
            if (addToCartDto is { ProductId: not null })
            {
                await _serviceFactory.GetOrderDetailService().HandleAddProductToCart(order, addToCartDto);
                return;
            }

            if (addToCartDto is { DiamondId: not null })
            {
                await _serviceFactory.GetOrderDetailService().HandleAddDiamondToCart(order, addToCartDto);
                return;
            }

            throw new BadRequestException("Either ProductId or DiamondId must be provided.");

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

        public async Task<bool> ChangeStaffOrStatus(ResponseStatusDto ord, string staffRole)
        {
            var currentOrder = await _unitOfWork.GetOrderRepository().GetByIdAsync(ord.OrderId);
            if (currentOrder is null)
            {
                return false;
            }

            switch (staffRole)
            {
                case "SalesStaff":
                    currentOrder.SalesStaffId = (ord.StakeholderId.ToString().IsNullOrEmpty()) ? Guid.Empty : ord.StakeholderId;
                    break;
                case "DeliveryStaff":
                    currentOrder.DeliveryStaffId = (ord.StakeholderId.ToString().IsNullOrEmpty()) ? Guid.Empty : ord.StakeholderId;
                    break;
                default:
                    return false;
            }

            if (!currentOrder.Status.Equals(ord.UpdatedStatus))
            {
                currentOrder.Status = ord.UpdatedStatus;
            }
            await _unitOfWork.GetOrderRepository().UpdateAsync(currentOrder);
            return true;
        }
    }
}