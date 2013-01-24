using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRentalPos.Areas.Admin.Models.Store
{
    public class CreateStoreModel
    {
        public StoreModel Store { get; set; }
        public List<StoreAddressModel> StoreAddress { get; set; }
        public string JsonModel { get; set; }
        public IEnumerable<string> Urls { get; set; }
    }
}