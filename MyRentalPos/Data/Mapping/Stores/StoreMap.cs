using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Data.Mapping.Stores
{
    public class StoreMap : EntityTypeConfiguration<Store>
    {
        public StoreMap()
        {
            ToTable("Store");
        }
    }
}