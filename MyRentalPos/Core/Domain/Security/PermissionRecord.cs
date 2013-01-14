using System.Collections.Generic;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;

namespace MyRentalPos.Core.Domain.Security
{
    /// <summary>
    /// Represents a permission record
    /// </summary>
    public class PermissionRecord : BaseEntity
    {
        private ICollection<EmployeeRole> _employeeRole;

        public PermissionRecord()
        {
        }
        /// <summary>
        /// Gets or sets the permission name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the permission system name
        /// </summary>
        public virtual string SystemName { get; set; }
        
        /// <summary>
        /// Gets or sets the permission category
        /// </summary>
        public virtual string Category { get; set; }
        
        /// <summary>
        /// Gets or sets discount usage history
        /// </summary>

        public virtual ICollection<EmployeeRole> EmployeeRoles
        {
            get { return _employeeRole ?? (_employeeRole = new List<EmployeeRole>()); }
            protected set { _employeeRole = value; }
        }

    }
}
