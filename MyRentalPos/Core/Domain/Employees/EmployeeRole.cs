using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Security;

namespace MyRentalPos.Core.Domain.Employees
{
    public class EmployeeRole : BaseEntity
    {
        private ICollection<PermissionRecord> _permissionRecords;
        private ICollection<Employee> _employees;
        public string Name { get; set; }
        public bool Active { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the customer role is system
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// Gets or sets the customer role system name
        /// </summary>
        public string SystemName { get; set; }


        public bool IsGlobal { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get { return _employees ?? (_employees = new List<Employee>()); }
            protected set { _employees = value; }
        }

        public virtual ICollection<PermissionRecord> PermissionRecords
        {
            get { return _permissionRecords ?? (_permissionRecords = new List<PermissionRecord>()); }
            protected set { _permissionRecords = value; }
        }
    }
}