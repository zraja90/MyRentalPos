using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Orders;

namespace MyRentalPos.Data.Mapping.Orders
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");

            HasRequired(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Store)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.StoreId);
        }
    }
}