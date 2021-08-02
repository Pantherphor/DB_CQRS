using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using DB_CQRS.DB.EntityFrameword;
using Microsoft.OpenApi.Models;

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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DB_CQRS UI", Version = "v1", Description = "Try the Post execution and go to: https://localhost:5001/cap to get to the CAP Dashboard." });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DB_CQRS.UI v1"));
            }

            app.UseRouting();

            app.MapEFDatabase();
            app.MapSaveOrders();
        }
    }
}
