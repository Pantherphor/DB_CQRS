using DB_CQRS.Shared.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DB_CQRS.DB.Driver.EntityFramework
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddDbContext<OrderDBContext>();
            services.AddSingleton<IOrderRespository, OrderRespository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}