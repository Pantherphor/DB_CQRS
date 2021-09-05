using DB_CQRS.Shared;
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;

namespace DB_CQRS.DB.CommandQueryHandler
{
    [CapSubscribe(nameof(OrderPlaced))]
    public class OrderCommandHandlers : ICapSubscribe
    {
        private readonly ILogger<OrderCommandHandlers> _logger;
        public OrderCommandHandlers(ILogger<OrderCommandHandlers> logger)
        {
            _logger = logger;
        }

        [CapSubscribe(nameof(OrderPlaced), Group ="create")]
        public void Handle(OrderPlaced orderPlaced)
        {
            _logger.LogInformation($"Placed order id: {orderPlaced.OrderId}");
        }
    }
}
