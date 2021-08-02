using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using DB_CQRS.DB.EntityFrameword;

namespace DB_CQRS.Web.Endpoints
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEFDatabase();
            services.AddHostedZeroMQ(Configuration);
            services.AddCap();
            services.AddControllers();
            services.AddSwaggerUIGenerator();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUIGenerator();
            }

            app.UseRouting();

            app.MapEFDatabase();
            app.MapSaveOrders();
        }
    }
}
