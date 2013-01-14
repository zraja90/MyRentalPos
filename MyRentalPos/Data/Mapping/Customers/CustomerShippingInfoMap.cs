using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Customers;

namespace MyRentalPos.Data.Mapping.Customers
{
    public class CustomerShippingInfoMap : EntityTypeConfiguration<CustomerShippingInfo>
    {
        public CustomerShippingInfoMap()
        {
            ToTable("CustomerShippingInfo");
            //Relationships
            HasRequired(x => x.Customer)
                .WithMany(x => x.CustomerShippingInfos)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}