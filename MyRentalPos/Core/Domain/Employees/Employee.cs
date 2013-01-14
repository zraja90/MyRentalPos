using System;
using System.Collections.Generic;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Core.Domain.Employees
{
    public class Employee : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }

        private ICollection<EmployeeRole> _employeeRoles;

        public ICollection<EmployeeRole> EmployeeRoles
        {
            get { return _employeeRoles ?? (_employeeRoles = new List<EmployeeRole>()); }
            protected set { _employeeRoles = value; }
        }

        public DateTime LastActivityDateUtc { get; set; }

        public DateTime LastLoginDateUtc { get; set; }
    }
}