using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Products;

namespace MyRentalPos.Data.Mapping.Products
{
    public class RequestAQuoteMap : EntityTypeConfiguration<RequestAQuote>
    {
        public RequestAQuoteMap()
        {
            this.ToTable("RequestAQuote");
            this.HasKey(l => l.Id);
            this.Property(l => l.CompanyName).IsRequired();
            this.Property(l => l.Email).IsRequired();
            this.Property(l => l.FirstName);
            this.Property(l => l.LastName);
            this.Property(l => l.CreatedDate);
            this.Property(l => l.PhoneNumber);
            this.Property(l => l.Message);

        }
    }
}