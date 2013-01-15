using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRentalPos.Core.Domain.Order;
using MyRentalPos.Services.CustomerService;
using MyRentalPos.Services.OrdersService;

namespace MyRentalPos.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly ICustomerService _customerService;
        public OrdersController(IOrdersService ordersService, ICustomerService customerService)
        {
            _ordersService = ordersService;
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            var guestCustomer = _customerService.Get(x => x.FirstName == "Guest" && x.Email == "Guest@myrentalpos.com");
            var order = new Orders
                            {
                                CreatedDate = DateTime.UtcNow,
                                OrderStatus = EnumOrderStatus.Pending,
                                StoreId = 1,
                                CustomerId = guestCustomer.Id
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