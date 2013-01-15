using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Core.Domain.Stores;
using MyRentalPos.Helpers;
using MyRentalPos.Services.Authentication;
using MyRentalPos.Services.CustomerService;
using MyRentalPos.Services.Employees;
using MyRentalPos.Services.Stores;

namespace MyRentalPos.Infrastructure
{
    public class WorkContext : IWorkContext
    {
        private readonly HttpContextBase _httpContext;
        private readonly IEmployeeService _employeeService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IWebHelper _webHelper;
        private readonly IStoreService _storeService;
        private Employee _cachedEmployee;


        public WorkContext(HttpContextBase httpContext,
                             IEmployeeService employeeService,
                             IAuthenticationService authenticationService,
                             IWebHelper webHelper, IStoreService storeService
                              )
        {
            this._httpContext = httpContext;
            this._employeeService = employeeService;
            this._authenticationService = authenticationService;
            this._webHelper = webHelper;
            _storeService = storeService;
        }
        private bool IsAuthenticated
        {
            get { return _httpContext.Request.IsAuthenticated; }
        }
        protected Employee GetCurrentEmployee()
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
            if (employee != null && employee.Active)
            {
                //update last activity date
                if (employee.LastActivityDateUtc.AddMinutes(1.0) < DateTime.UtcNow)
                {
                    employee.LastActivityDateUtc = DateTime.UtcNow;
                    _employeeService.Update(employee);
                }

                _cachedEmployee = employee;
            }

            return _cachedEmployee;
        }
        public Employee CurrentEmployee
        {
            get
            {
                return GetCurrentEmployee();
            }
            set
            {
                _cachedEmployee = value;
            }
        }

        public Store CurrentStore
        {
            get
            {
                var store = new Store();
                if (StoreId > 0)
                    store = _storeService.GetById(StoreId);
                return store;
            }
        }

        public bool IsLoggedIn
        {
            get { return IsAuthenticated; }

        }

        public string LogoutUrl
        {
            get { return "/"; }
        }

        private int _storeId;
        public int StoreId
        {
            get
            { //get data from cookie
                if (_storeId == 0)
                    _storeId = StoreHelper.GetStoreIdFromCookie();
                return _storeId; 
            }
        }
    }
}