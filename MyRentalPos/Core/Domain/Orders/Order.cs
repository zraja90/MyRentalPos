using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Core.Domain.Orders
{
    public class Order : BaseEntity
    {
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}