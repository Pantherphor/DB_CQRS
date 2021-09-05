using DB_CQRS.DB.Driver.EntityFramework.Configuration;
using DB_CQRS.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DB_CQRS.DB.Driver.EntityFramework
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
