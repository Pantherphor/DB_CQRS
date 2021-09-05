using DB_CQRS.Shared.Data;
using System;

namespace DB_CQRS.DB.Driver.EntityFramework.Data
{
    public class SeedData
    {
        internal static void Initialize(OrderDBContext db)
        {
            var orders = new Order[]
            {
                new Order
                {
                    UserId = 1,
                    OrderId = Guid.NewGuid(),
                    CreatedTime = DateTime.Now.AddMinutes(-15),
                    OrderStatus = OrderStatus.Placed,
                },
                new Order
                {
                    UserId = 2,
                    OrderId = Guid.NewGuid(),
                    CreatedTime = DateTime.Now.AddMinutes(-20),
                    OrderStatus = OrderStatus.Preparing,
                },
                new Order
                {
                    UserId = 3,
                    OrderId = Guid.NewGuid(),
                    CreatedTime = DateTime.Now.AddMinutes(-45),
                    OrderStatus = OrderStatus.OutForDelivery,
                },
                new Order
                {
                    UserId = 4,
                    OrderId = Guid.NewGuid(),
                    CreatedTime = DateTime.Now.AddMinutes(-55),
                    OrderStatus = OrderStatus.Delivered,
                },
            };

            db.Orders.AddRange(orders);
            db.SaveChangesAsync();
        }
    }
}
