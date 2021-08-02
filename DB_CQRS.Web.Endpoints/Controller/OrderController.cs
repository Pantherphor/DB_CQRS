using DB_CQRS.Shared;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DB_CQRS.Web.Endpoints.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICapPublisher _capPublisher;

        public OrderController(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        [HttpPost]
        public async Task<string> Post()
        {
            var orderPlaced = new OrderPlaced
            {
                OrderId = Guid.NewGuid()
            };
            await _capPublisher.PublishAsync(nameof(OrderPlaced), orderPlaced);

            return await Task.FromResult($"Order {orderPlaced.OrderId} has been placed.");
        }

    }
}
