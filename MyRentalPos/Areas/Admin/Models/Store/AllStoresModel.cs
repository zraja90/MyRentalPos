using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRentalPos.Areas.Admin.Models.Store
{
    public class AllStoresModel
    {
        public IEnumerable<Core.Domain.Stores.Store> Stores { get; set; }
    }
}