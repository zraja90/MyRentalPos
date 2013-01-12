using System;
using System.Web;
using System.Web.Security;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Services.CustomerService;

namespace MyRentalPos.Services.Authentication
{
    public partial class FormsAuthenticationService : IAuthenticationService
    {

        private readonly HttpContextBase _httpContext;
        private readonly ICustomerService _customerService;
        private readonly TimeSpan _expirationTimeSpan;

        private Employee _cachedEmployee;

        public FormsAuthenticationService(HttpContextBase httpContext,
            ICustomerService customerService)
        {
            this._httpContext = httpContext;
            this._customerService = customerService;
            this._expirationTimeSpan = FormsAuthentication.Timeout;
        }

        public void Login(Employee employee, bool persistentCookie)
        {
            FormsAuthentication.SetAuthCookie(employee.Id.ToString(), persistentCookie);
        }


        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public Employee GetAuthenticatedEmployee()
        {
            if (_cachedEmployee != null)
                return _cachedEmployee;

            if (_httpContext == null ||
                _httpContext.Request == null ||
                !_httpContext.Request.IsAuthenticated ||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            //var userName = _httpContext.User.Identity.Name;
            //var user = _userService.GetUserByEmail(userName);
            var customerId = _httpContext.User.Identity.Name;
            var customer = _customerService.GetById(Convert.ToInt32(customerId));


            if (customer != null && customer.Active && !customer.Deleted)
                _cachedEmployee = customer;
            return _cachedEmployee;
        }
    }
}
