using System;
using System.Collections.Generic;
using System.Linq;
using MyRentalPos.Core;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Core.Domain.Security;
using MyRentalPos.Data;

namespace MyRentalPos.Services.Security
{
    /// <summary>
    /// Permission service
    /// </summary>
    public partial class PermissionService : IPermissionService
    {
        #region Constants
        /// <summary>
        /// Cache key for storing a valie indicating whether a certain customer role has a permission
        /// </summary>
        /// <remarks>
        /// {0} : customer role id
        /// {1} : permission system name
        /// </remarks>
        private const string PERMISSIONS_ALLOWED_KEY = "MyRentalPos.permission.allowed-{0}-{1}";
        private const string PERMISSIONS_PATTERN_KEY = "MyRentalPos.permission.";
        #endregion

        #region Fields

        private readonly IRepository<PermissionRecord> _permissionPecordRepository;
        //private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        //private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        public PermissionService(IRepository<PermissionRecord> permissionPecordRepository,
            IWorkContext workContext)
        {
            _permissionPecordRepository = permissionPecordRepository;
            _workContext = workContext;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="employeeRole">Customer role</param>
        /// <returns>true - authorized; otherwise, false</returns>
        protected virtual bool Authorize(string permissionRecordSystemName, EmployeeRole employeeRole)
        {
            if (String.IsNullOrEmpty(permissionRecordSystemName))
                return false;

            string key = string.Format(PERMISSIONS_ALLOWED_KEY, employeeRole.Id, permissionRecordSystemName);
            foreach (var permission1 in employeeRole.PermissionRecords)
                if (permission1.SystemName.Equals(permissionRecordSystemName, StringComparison.InvariantCultureIgnoreCase))
                    return true;

            return false;

        }

        #endregion

        #region Methods


        public virtual bool Authorize(PermissionRecord permission, EmployeeRole employeeRole)
        {
            return Authorize(permission.SystemName, employeeRole);
        }

        /// <summary>
        /// Delete a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void DeletePermissionRecord(PermissionRecord permission)
        {
            if (permission == null)
                throw new ArgumentNullException("permission");

            _permissionPecordRepository.Delete(permission);

            // _cacheManager.RemoveByPattern(PERMISSIONS_PATTERN_KEY);
        }

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="permissionId">Permission identifier</param>
        /// <returns>Permission</returns>
        public virtual PermissionRecord GetPermissionRecordById(int permissionId)
        {
            if (permissionId == 0)
                return null;

            return _permissionPecordRepository.GetById(permissionId);
        }

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="systemName">Permission system name</param>
        /// <returns>Permission</returns>
        public virtual PermissionRecord GetPermissionRecordBySystemName(string systemName)
        {
            if (String.IsNullOrWhiteSpace(systemName))
                return null;

            var query = from pr in _permissionPecordRepository.Table
                        where pr.SystemName == systemName
                        orderby pr.Id
                        select pr;

            var permissionRecord = query.FirstOrDefault();
            return permissionRecord;
        }

        /// <summary>
        /// Gets all permissions
        /// </summary>
        /// <returns>Permissions</returns>
        public virtual IList<PermissionRecord> GetAllPermissionRecords()
        {
            var query = from pr in _permissionPecordRepository.Table
                        orderby pr.Name
                        select pr;
            var permissions = query.ToList();
            return permissions;
        }

        /// <summary>
        /// Inserts a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void InsertPermissionRecord(PermissionRecord permission)
        {
            if (permission == null)
                throw new ArgumentNullException("permission");

            _permissionPecordRepository.Add(permission);

            //_cacheManager.RemoveByPattern(PERMISSIONS_PATTERN_KEY);
        }

        /// <summary>
        /// Updates the permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void UpdatePermissionRecord(PermissionRecord permission)
        {
            if (permission == null)
                throw new ArgumentNullException("permission");

            _permissionPecordRepository.Update(permission);

            //   _cacheManager.RemoveByPattern(PERMISSIONS_PATTERN_KEY);
        }


        /// <summary>
        /// Uninstall permissions
        /// </summary>
        /// <param name="permissionProvider">Permission provider</param>
        public virtual void UninstallPermissions(IPermissionProvider permissionProvider)
        {
            var permissions = permissionProvider.GetPermissions();
            foreach (var permission in permissions)
            {
                var permission1 = GetPermissionRecordBySystemName(permission.SystemName);
                if (permission1 != null)
                {
                    DeletePermissionRecord(permission1);
                }
            }
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(PermissionRecord permission)
        {
            return Authorize(permission, _workContext.CurrentEmployee);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(PermissionRecord permission, Employee employee)
        {
            if (permission == null)
                return false;

            if (employee == null)
                return false;

            return Authorize(permission.SystemName, employee);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(string permissionRecordSystemName)
        {
            return Authorize(permissionRecordSystemName, _workContext.CurrentEmployee);

        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(string permissionRecordSystemName, Employee employee)
        {
            if (String.IsNullOrEmpty(permissionRecordSystemName))
                return false;

            var customerRoles = employee.EmployeeRoles.Where(cr => cr.Active);
            foreach (var role in customerRoles)
                if (Authorize(permissionRecordSystemName, role))
                    //yes, we have such permission
                    return true;

            //no permission found
            return false;
        }


        /// <summary>
        /// Install permissions
        /// </summary>
        /// <param name="permissionProvider">Permission provider</param>
        public virtual void InstallPermissions(IPermissionProvider permissionProvider)
        {
            //install new permissions
            var permissions = permissionProvider.GetPermissions();
            foreach (var permission in permissions)
            {
                var permission1 = GetPermissionRecordBySystemName(permission.SystemName);
                if (permission1 == null)
                {
                    //new permission (install it)
                    permission1 = new PermissionRecord
                                      {
                                          Name = permission.Name,
                                          SystemName = permission.SystemName,
                                          Category = permission.Category,
                                      };


                    //default customer role mappings
                    var defaultPermissions = permissionProvider.GetDefaultPermissions();
                    foreach (var defaultPermission in defaultPermissions)
                    {
                        //var employeeRole = _customerService.GetCustomerRoleBySystemName(defaultPermission.CustomerRoleSystemName);
                        /* if (employeeRole == null)
                         {
                             //new role (save it)
                             employeeRole = new CustomerRole()
                             {
                                 Name = defaultPermission.CustomerRoleSystemName,
                                 Active = true,
                                 SystemName = defaultPermission.CustomerRoleSystemName
                             };
                             _customerService.InsertCustomerRole(employeeRole);
                         }


                         var defaultMappingProvided = (from p in defaultPermission.PermissionRecords
                                                       where p.SystemName == permission1.SystemName
                                                       select p).Any();
                         var mappingExists = (from p in employeeRole.PermissionRecords
                                              where p.SystemName == permission1.SystemName
                                              select p).Any();
                         if (defaultMappingProvided && !mappingExists)
                         {
                             permission1.CustomerRoles.Add(employeeRole);
                         }*/
                    }

                    //save new permission
                    InsertPermissionRecord(permission1);
                }
            }
        }



        #endregion
    }
}