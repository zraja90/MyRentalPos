using System.Collections.Generic;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Core.Domain.Security;

namespace MyRentalPos.Services.Security
{
    public partial class StandardPermissionProvider : IPermissionProvider
    {
        //admin area permissions
        public static readonly PermissionRecord AccessAdminPanel = new PermissionRecord
        {
            Name = "Access admin area",
            SystemName = "AccessAdminPanel",
            Category = "Standard"
        };
        
        public virtual IEnumerable<PermissionRecord> GetPermissions()
        {
            return new[]
                       {
                            AccessAdminPanel
                       };
        }

        public IEnumerable<DefaultPermissionRecord> GetDefaultPermissions()
        {
            return new[]
                       {
                           new DefaultPermissionRecord
                               {
                                   CustomerRoleSystemName = EnumEmployeeRoleNames.Admin,
                                   PermissionRecords = new[]
                                                {
                                                    AccessAdminPanel
                                                }
                               }
                       };
        }
    }
}