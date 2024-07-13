using System.Security.Claims;
using DiamondShop.BusinessLogic.Extensions;
using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Order;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
using DiamondShop.DataAccess.Interfaces;
using DiamondShop.DataAccess.Models;
using DiamondShop.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<List<Order>> GetOrdersByStatus(ClaimsPrincipal claims, OrderStatus status)
        {
            var account = await _unitOfWork.GetAccountRepository().GetAccountDetail(claims.GetAccountId())
                ?? throw new NotFoundException("Unknow account currently request this!");

            if (account.Customer is null) throw new NotFoundException("Unknow customer to load out the orders");

            var customerId = account.Customer.Id;

            var list = await _unitOfWork.GetOrderRepository().FindAsync(ord => ord.CustomerId == customerId && ord.Status.ToLower()!.Equals(status.ToString().ToLower()));
            
            if (list.Count() == 0) throw new NotFoundException("Not Found Any Order");
            return list;
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            var foundOrder = await _unitOfWork.GetOrderRepository().GetByIdAsync(id)
                ?? throw new NotFoundException("Not found this order");
            return foundOrder;
        }

        public async Task<PagedResult<Order>?> GetList(QueryOrderDto query)
        {
            var foundOrder = await _unitOfWork.GetOrderRepository().GetListAsync(query)
                ?? throw new NotFoundException("Not found available order");
            return foundOrder;
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

        public async Task<bool> UpdateStatus(Guid ordId, string newStatus, string interacterRole)
        {
            var currentOrder = await _unitOfWork.GetOrderRepository().GetByIdAsync(ordId)
                ?? throw new NotFoundException("Not found this Order");

            if (currentOrder.Status!.ToLower().Equals(newStatus.ToLower()))
                throw new BadRequestException("New status is same as previous status!");

            //Validate suitable status of each role
            switch (interacterRole)
            {
                case "Customer":
                    if (!OrderStatusOf_Customer.Contains(newStatus.ToLower()))
                        throw new BadRequestException("Invalid order status for customer to update");
                    break;

                case "SalesStaff":
                    if (!OrderStatusOf_SalesStaff.Contains(newStatus.ToLower()))
                        throw new BadRequestException("Invalid order status for Sales Staff to update");
                    break;

                case "DeliveryStaff":
                    if (!OrderStatusOf_DeliveryStaff.Contains(newStatus.ToLower()))
                    {
                        throw new BadRequestException("Invalid order status for Delivery Staff to update");
                    }
                    else
                    {//If valid
                        currentOrder.ShipDate = DateTime.Now;
                    }
                    break;
                default:
                    throw new BadRequestException("Invalid role to interact to this method");
            }

            //Then change Status
            currentOrder.Status = newStatus;

            //Save Change
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateOrder(OrderInfoDto order)
        {
            var existOrder = await _unitOfWork.GetOrderRepository().FindOneAsync(ord => ord.Id == order.OrderId)
                ?? throw new NotFoundException("Not found this order");

            if (order.SalesStaffId != Guid.Empty)
            { existOrder.SalesStaffId = order.SalesStaffId; }

            if (order.DeliveryStaffId != Guid.Empty)
            { existOrder.DeliveryStaffId = order.DeliveryStaffId; }

            existOrder.Code = order.Code;
            existOrder.Total = order.Total;
            existOrder.ShipAddress = order.ShipAddress;
            existOrder.Note = order.Note;

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            var currentOrder = await _unitOfWork.GetOrderRepository().GetByIdAsync(orderId);
            if (currentOrder is null)
            {
                throw new NotFoundException("Cannot found that order");
            }
            CheckDeleted(currentOrder.Status!);

            currentOrder.Status = "Deleted";

            //Save Change
            await _unitOfWork.GetOrderRepository().UpdateAsync(currentOrder);
            return true;
        }

        public async Task<OrderStatistic> GetOrderStatisticsAsync(int month)
        {
            var orders = await _unitOfWork.GetOrderRepository().GetAllAsync();

            if (month != 0 && (month >= 1 && month <= 12))
            {
                orders = orders.Where(o => o.OrderDate.Month == month).ToList();
            }
            var totalOrders = orders.Count;
            var totalRevenue = orders.Sum(o => o.Total);
            var averageOrderValue = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            return new OrderStatistic
            {
                TotalOrders = totalOrders,
                TotalRevenue = totalRevenue,
                AverageOrderValue = averageOrderValue,
            };
        }

        public async Task<DashboardStats> getDashBoardStats()
        {
            var numberofDiamonds = _unitOfWork.GetDiamondRepository().GetAllAsync().Result.Count();
            var numberofProdducts = _unitOfWork.GetProductRepository().GetAllAsync().Result.Count();
            var totalRevenue = _unitOfWork.GetOrderRepository().GetAllAsync().Result.Sum(o => o.Total);
            return new DashboardStats
            {
                numberOfDiamonds = numberofDiamonds,
                numberOfProducts = numberofProdducts,
                totalRevenue = totalRevenue,
                Profit = totalRevenue * 0.1m
            };
        }

        //===================================================================================================================
        private static readonly HashSet<string> OrderStatusOf_Customer = new HashSet<string>()
        {
            //Cancel Buying
            OrderStatus.InCart.ToString().ToLower(),

            //Start Buying
            OrderStatus.Pending_Confirm.ToString().ToLower(),

            //Refund
            OrderStatus.Pending_Refund.ToString().ToLower()
        };

        private static readonly HashSet<string> OrderStatusOf_SalesStaff = new HashSet<string>()
        {
            //Receive customer order
            OrderStatus.Confirmed.ToString().ToLower(),

            //Confirm Pay
            OrderStatus.Pending_Deliver.ToString().ToLower(),

            //Refund
            OrderStatus.Refunded.ToString().ToLower()
        };

        private static readonly HashSet<string> OrderStatusOf_DeliveryStaff = new HashSet<string>()
        {
            //Receive customer order
            OrderStatus.Delivering.ToString().ToLower(),

            //After delivery
            OrderStatus.Deliveried.ToString().ToLower(),
        };
        private static void CheckDeleted(string orderStatus)
        {
            if (orderStatus.ToLower().Equals("Deleted".ToLower())) throw new BadRequestException("This order already deleted!");
        }

    }
}