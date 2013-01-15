using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRentalPos.Core;
using MyRentalPos.Core.Common;
using MyRentalPos.Core.Domain.Order;
using MyRentalPos.Models;
using MyRentalPos.Models.Order;
using MyRentalPos.Services.Authentication;
using MyRentalPos.Services.Employees;
using MyRentalPos.Services.OrdersService;

namespace MyRentalPos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRegistrationService _employeeRegistrationService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IWorkContext _workContext;
        public HomeController(IOrdersService ordersService, IEmployeeRegistrationService employeeRegistrationService, IEmployeeService employeeService,
            IAuthenticationService authenticationService, IWorkContext workContext)
        {
            _workContext = workContext;
            _authenticationService = authenticationService;
            _ordersService = ordersService;
            _employeeRegistrationService = employeeRegistrationService;
            _employeeService = employeeService;
        }

        public ActionResult Index()
        {
            var id = _workContext.StoreId;
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

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var model = new LoginModel();

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_employeeRegistrationService.ValidateEmployee(model.UserName, model.Password))
                {

                    var customer = _employeeService.GetCustomerByUserName(model.UserName);
                    customer.LastLoginDateUtc = DateTime.UtcNow;
                    _employeeService.Update(customer);
                    //sign in new employee
                    _authenticationService.Login(customer, model.RememberMe);

                    return RedirectToLocal(returnUrl);
                }
            }


            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            var returnUrl = _workContext.LogoutUrl;
            
            _authenticationService.Logout();
            CookieHelper.DeleteAllCookies();

            if (!string.IsNullOrEmpty(returnUrl))
            {
                if (!returnUrl.ToLower().Contains("http://"))
                    returnUrl = "http://" + returnUrl;
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        #endregion

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
