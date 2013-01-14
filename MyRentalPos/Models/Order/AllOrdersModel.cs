using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Order;

namespace MyRentalPos.Models.Order
{
    public class AllOrdersModel
    {
        public IEnumerable<Orders> CompletedOrders { get; set; }
        public IEnumerable<Orders> CancelledOrders { get; set; }
        public IEnumerable<Orders> SavedOrders { get; set; } 
    }
}