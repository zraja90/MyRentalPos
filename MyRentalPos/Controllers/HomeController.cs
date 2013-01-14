using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRentalPos.Core.Domain.Order;
using MyRentalPos.Models.Order;
using MyRentalPos.Services.OrdersService;

namespace MyRentalPos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrdersService _ordersService;
        public HomeController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public ActionResult Index()
        {
            var model = new AllOrdersModel
                            {
                                CompletedOrders = _ordersService.GetMany(x => x.OrderStatus == EnumOrderStatus.Completed),
                                CancelledOrders = _ordersService.GetMany(x => x.OrderStatus == EnumOrderStatus.Denied),
                                SavedOrders = _ordersService.GetMany(x => x.OrderStatus == EnumOrderStatus.Saved)
                            };
            
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
