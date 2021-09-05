using Microsoft.Extensions.DependencyInjection;

namespace DB_CQRS.DB.CommandQueryHandler
{
    public static class ConfigureServices
    {
        public static void AddEFDatabase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<OrderCommandHandlers>();
        }
    }
}
