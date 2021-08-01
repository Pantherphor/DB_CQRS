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

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEFDatabase();
            services.AddHostedZeroMQ(Configuration);
            //services.AddHostedZeroMQ(Configuration);
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.MapEFDatabase();
            app.MapSaveOrders();
        }
    }
}
