using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Products;

namespace MyRentalPos.Data.Mapping.Products
{
    public class RentalPricesMap: EntityTypeConfiguration<RentalPrices>
    {
        public RentalPricesMap()
        {
            ToTable("RentalPrices");

            HasRequired(x => x.Product)
                .WithMany(x => x.RentalPrices)
                .HasForeignKey(x => x.ProductId);
        }
    }
}