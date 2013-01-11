﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Products;

namespace MyRentalPos.Data.Mapping.Products
{
    public class ProductSpecsMap : EntityTypeConfiguration<ProductSpecs>
    {
        public ProductSpecsMap()
        {
            this.ToTable("ProductSpecs");
            Property(t => t.SpecType);
            this.Property(t => t.SpecName);

            HasRequired(t => t.Product)
                .WithMany(p => p.ProductSpecs)
                .HasForeignKey(t => t.ProductId);
        }
    }
}