using DB_CQRS.Shared;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DB_CQRS.Web.Endpoints.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ICapPublisher _capPublisher;

        public OrderController(ILogger<OrderController> logger, ICapPublisher capPublisher)
        {
            _logger = logger;
            _capPublisher = capPublisher;
        }

        [HttpPost]
        public async Task<string> Post()
        {
            var orderPlaced = new OrderPlaced
            {
                OrderId = Guid.NewGuid()
            };

            _logger.LogInformation($"publishing {nameof(orderPlaced.OrderId)}");
            await _capPublisher.PublishAsync(nameof(OrderPlaced), orderPlaced);
            _logger.LogInformation($"published {nameof(orderPlaced.OrderId)}");

            return await Task.FromResult($"Order {orderPlaced.OrderId} has been placed.");
        }

    }
}
