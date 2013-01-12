using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Services.Authentication;
using MyRentalPos.Services.CustomerService;
using MyRentalPos.Services.Employees;

namespace MyRentalPos.Infrastructure
{
    public class WorkContext : IWorkContext
    {
        private readonly HttpContextBase _httpContext;
        private readonly IEmployeeService _employeeService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IWebHelper _webHelper;
        private Employee _cachedEmployee;
        

        public WorkContext(HttpContextBase httpContext,
                             IEmployeeService employeeService,
                             IAuthenticationService authenticationService,
                             IWebHelper webHelper
                              )
        {
            this._httpContext = httpContext;
            this._employeeService = employeeService;
            this._authenticationService = authenticationService;
            this._webHelper = webHelper;
        }
        private bool IsAuthenticated
        {
            get { return _httpContext.Request.IsAuthenticated; }
        }
        protected Customer GetCurrentCustomer()
        {
            if (_cachedEmployee != null)
                return _cachedEmployee;

            if (!IsAuthenticated)
                return null;

            Employee employee = null;
            if (_httpContext != null)
            {
                employee = _authenticationService.GetAuthenticatedEmployee();
            }

            //validation
            if (employee != null && !employee.Deleted && employee.Active)
            {
                //update last activity date
                if (employee.LastActivityDateUtc.AddMinutes(1.0) < DateTime.UtcNow)
                {
                    employee.LastActivityDateUtc = DateTime.UtcNow;
                    _employeeService.Update(employee);
                }

                //update IP address
                string currentIpAddress = _webHelper.GetCurrentIpAddress();
                if (!String.IsNullOrEmpty(currentIpAddress))
                {
                    if (!currentIpAddress.Equals(employee.LastIpAddress))
                    {
                        employee.LastIpAddress = currentIpAddress;
                        _employeeService.Update(employee);
                    }
                }

                _cachedEmployee = employee;
            }

            return _cachedCustomer;
        }
        public Customer CurrentCustomer
        {
            get
            {
                return GetCurrentCustomer();
            }
            set
            {
                _cachedEmployee = value;
            }
        }
        public bool IsLoggedIn
        {
            get { return IsAuthenticated; }

        }

        public string LogoutUrl
        {
            get { return "http://localhost:65403/"; }
        }

    }
}