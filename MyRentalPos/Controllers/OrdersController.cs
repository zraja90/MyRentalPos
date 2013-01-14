using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRentalPos.Core.Domain.Order;
using MyRentalPos.Services.OrdersService;

namespace MyRentalPos.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public ActionResult Index()
        {
            var order = new Orders
                            {
                                CreatedDate = DateTime.UtcNow,
                                OrderStatus = EnumOrderStatus.Pending,
                                StoreId = 1,
                                CustomerId = 2
                            };
            _ordersService.Add(order);

            return Redirect("/Orders/Order/" + order.Id);
        }

        public ActionResult Order(int id=0)
        {
            ViewBag.Id = id;
            return View();
        }

    }
}