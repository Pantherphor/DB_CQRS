﻿using DB_CQRS.DB.Driver.EntityFramework.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DB_CQRS.DB.Driver.EntityFramework
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<OrderDBContext>();
                if (db.Database.EnsureCreated())
                {
                    SeedData.Initialize(db);
                }
            }

            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder => webBuilder.UseStartup<Startup>());
    }
}
