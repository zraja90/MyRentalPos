using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Customers;

namespace MyRentalPos.Data.Mapping.Customers
{
    public class EmailSubscriptionMap : EntityTypeConfiguration<EmailSubscription>
    {
        public EmailSubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            ToTable("EmailSubscription");
            Property(t => t.EmailAddress);
            Property(t => t.Subscribed);
            Property(t => t.CreatedDate);
        }
    }
}