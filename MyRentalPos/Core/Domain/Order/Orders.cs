using System;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Core.Domain.Order
{
    public class Orders : BaseEntity
    {
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}