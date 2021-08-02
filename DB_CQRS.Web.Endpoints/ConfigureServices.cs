using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DB_CQRS.Web.Endpoints
{
    public static class ConfigureServices
    {
        public static void AddCap(this IServiceCollection services)
        {
            services.AddCap(config =>
            {
                config.ConsumerThreadCount = 1;
                config.UseInMemoryStorage();
                config.UseZeroMQ(config =>
                {
                    config.HostName = "127.0.0.1";
                    config.SubPort = 5556;
                    config.PubPort = 5557;
                    config.Pattern = MaiKeBing.CAP.NetMQPattern.PushPull;
                });
                config.UseDashboard();
            });
        }

        public static void AddSwaggerUIGenerator(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DB_CQRS UI", Version = "v1", Description = "Try the Post execution and go to: https://localhost:5001/cap to get to the CAP Dashboard." });
            });
        }
    }
}
