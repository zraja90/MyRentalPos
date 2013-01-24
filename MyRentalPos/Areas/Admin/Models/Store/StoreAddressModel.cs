using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRentalPos.Areas.Admin.Models.Store
{
    public class StoreAddressModel
    {
        public int StoreId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}