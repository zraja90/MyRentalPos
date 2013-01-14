using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Customers;

namespace MyRentalPos.Data.Mapping.Customers
{
    public class CustomerBillingInfoMap : EntityTypeConfiguration<CustomerBillingInfo>
    {
        public CustomerBillingInfoMap()
        {
            ToTable("CustomerBillingInfo");
            //Relationships
            HasRequired(x => x.Customer)
                .WithMany(x => x.CustomerBillingInfos)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}