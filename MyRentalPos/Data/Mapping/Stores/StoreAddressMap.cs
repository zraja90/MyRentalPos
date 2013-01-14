using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Data.Mapping.Stores
{
    public class StoreAddressMap : EntityTypeConfiguration<StoreAddress>
    {
        public StoreAddressMap()
        {
            ToTable("StoreAddress");

            HasRequired(x => x.Store)
                .WithMany(x => x.StoreAddress)
                .HasForeignKey(x => x.StoreId);
        }
    }
}