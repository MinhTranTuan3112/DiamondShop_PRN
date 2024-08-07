﻿using System.ComponentModel.DataAnnotations;

namespace DiamondShop.DataAccess.DTOs.Order
{
    public class QueryOrderDto
    {
        public int Size {  get; set; }
        public int Page {  get; set; }
        public Guid SalesStaffId { get; set; } = Guid.Empty;
        public Guid DeliveryStaffId { get; set; } = Guid.Empty;
        public string? Code { get; set; }
        public string? PayMethod { get; set; }
        public string? ShipAddress { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
        public bool OrderByCode { get; set; } = true;
        public bool IsDescendingCode { get; set; } = true;
        public bool IsDescendingDate { get; set; } = true;
    }
}
