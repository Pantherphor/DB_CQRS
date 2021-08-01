using DB_CQRS.Shared;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DB_CQRS.Web.Endpoints
{
    public static class Endpoints
    {
        public static void MapSaveOrders(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
                endpoints.MapPost("/save/order", async context =>
                {
                    var orderPlaced = new OrderPlaced
                    {
                        OrderId = Guid.NewGuid()
                    };
                    await context.RequestServices.GetService<ICapPublisher>().PublishAsync(nameof(OrderPlaced), orderPlaced);

                    await context.Response.WriteAsync($"Order {orderPlaced.OrderId} has been placed.");
                }));
        }
    }
}
