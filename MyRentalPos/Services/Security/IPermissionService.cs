using System.Collections.Generic;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Core.Domain.Security;

namespace MyRentalPos.Services.Security
{
    /// <summary>
    /// Permission service interface
    /// </summary>
    public partial interface IPermissionService
    {
        /// <summary>
        /// Delete a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        void DeletePermissionRecord(PermissionRecord permission);

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="permissionId">Permission identifier</param>
        /// <returns>Permission</returns>
        PermissionRecord GetPermissionRecordById(int permissionId);

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="systemName">Permission system name</param>
        /// <returns>Permission</returns>
        PermissionRecord GetPermissionRecordBySystemName(string systemName);

        /// <summary>
        /// Gets all permissions
        /// </summary>
        /// <returns>Permissions</returns>
        IList<PermissionRecord> GetAllPermissionRecords();

        /// <summary>
        /// Inserts a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        void InsertPermissionRecord(PermissionRecord permission);

        void UpdatePermissionRecord(PermissionRecord permission);


        void InstallPermissions(IPermissionProvider permissionProvider);

        void UninstallPermissions(IPermissionProvider permissionProvider);
    
        bool Authorize(PermissionRecord permission);

        bool Authorize(PermissionRecord permission, Employee employee);

        bool Authorize(PermissionRecord permission, EmployeeRole employeeRole);

        bool Authorize(string permissionRecordSystemName);

        bool Authorize(string permissionRecordSystemName, Employee employee);
    }
}