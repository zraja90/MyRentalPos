using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Products;

namespace MyRentalPos.Data.Mapping.Products
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.ToTable("Product");
            this.HasKey(t => t.Id);
            this.Property(t => t.Name);
            this.Property(t => t.Image).IsOptional();
            
            this.Property(t => t.Description).IsOptional();
            this.Property(t => t.CreatedDate);

            HasRequired(x => x.Store)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.StoreId);
        }
    }
}