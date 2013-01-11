using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRentalPos.Core.Domain.Customers
{
    public class CustomerShippingInfo : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}