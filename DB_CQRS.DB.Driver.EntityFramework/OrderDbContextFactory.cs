using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DB_CQRS.DB.Driver.EntityFramework
{
    public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDBContext>
    {
        public OrderDbContextFactory()
        {
        }

        private static IConfiguration Configuration => 
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public OrderDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OrderDBContext>();
            builder.UseSqlServer(Configuration.GetConnectionString("sqlserver"));

            return new OrderDBContext(builder.Options);
        }
    }
}
