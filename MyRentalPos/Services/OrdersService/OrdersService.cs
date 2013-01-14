using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Order;
using MyRentalPos.Data;

namespace MyRentalPos.Services.OrdersService
{
    public class OrdersService : CrudService<Orders>, IOrdersService
    {
        public OrdersService(IRepository<Orders> repo) : base(repo)
        {

        }
    }
}