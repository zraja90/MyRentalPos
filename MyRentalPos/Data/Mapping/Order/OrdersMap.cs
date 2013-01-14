using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Order;

namespace MyRentalPos.Data.Mapping.Order
{
    public class OrdersMap : EntityTypeConfiguration<Orders>
    {
        public OrdersMap()
        {
            ToTable("Orders");

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