﻿using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.OrderDetail;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IServiceFactory _serviceFactory;
        public OrderDetailsController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ViewDetail([FromRoute] Guid id)
        {
            return Ok(await _serviceFactory.GetOrderDetailService().Get_OrderDetail_By_Id(id));
        }

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetListByOrderId([FromRoute] Guid id)
        {
            return Ok(await _serviceFactory.GetOrderDetailService().GetList_OrderDetail_By_OrderId(id));
        }

        [HttpPost]
        public async Task<IActionResult> GetListByFilter([FromBody] OrderDetail_InfoDto filterInput)
        {
            return Ok(await _serviceFactory.GetOrderDetailService().GetList_OrderDetail_By_Filter(filterInput));
        }
        [HttpPatch]
        public async Task<IActionResult> Update(OrderDetail_InfoDto order)
        {
            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail()
        {
            return Ok();
        }
    }
}
