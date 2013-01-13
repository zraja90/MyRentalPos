using System;
using System.Web;
using System.Web.Security;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Services.CustomerService;
using MyRentalPos.Services.Employees;

namespace MyRentalPos.Services.Authentication
{
    public partial class FormsAuthenticationService : IAuthenticationService
    {

        private readonly HttpContextBase _httpContext;
        private readonly IEmployeeService _employeeService;
        private readonly TimeSpan _expirationTimeSpan;

        private Employee _cachedEmployee;

        public FormsAuthenticationService(HttpContextBase httpContext,
            IEmployeeService employeeService)
        {
            this._httpContext = httpContext;
            this._employeeService = employeeService;
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
            var customer = _employeeService.GetById(Convert.ToInt32(customerId));


            if (customer != null && customer.Active)
                _cachedEmployee = customer;
            return _cachedEmployee;
        }
    }
}
