using DB_CQRS.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DB_CQRS.DB.Driver.EntityFramework.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        private const string TABLE_NAME = "Order";
        
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(TABLE_NAME);
            builder.HasData(new List<Order>
            {
                new Order 
                { 
                    OrderId = Guid.NewGuid()
                }
            });

        }
    }
}
