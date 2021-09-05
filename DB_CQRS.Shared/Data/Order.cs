using System;

namespace DB_CQRS.Shared.Data
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Placed;
    }

    public enum OrderStatus
    {
        Placed = 0,
        Preparing = 1,
        OutForDelivery = 2,
        Delivered = 3
    }
}