using System;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Services.CustomerService;
using MyRentalPos.Services.Security;

namespace MyRentalPos.Services.Employees
{
    /// <summary>
    /// Customer registration service
    /// </summary>
    public partial class EmployeeRegistrationService : IEmployeeRegistrationService
    {
        #region Fields

        private readonly IEmployeeService _employeeService;
        private readonly IEncryptionService _encryptionService;
        //private readonly CustomerSettings _customerSettings;

        #endregion

        #region Ctor

        
        public EmployeeRegistrationService(IEmployeeService employeeService, 
            IEncryptionService encryptionService)
        {
            this._employeeService = employeeService;
            this._encryptionService = encryptionService;
        }

        #endregion

        #region Methods


        public virtual bool ValidateEmployee(string email, string password)
        {
            Employee employee = null;
            employee = _employeeService.Get(x => x.Email == email);

            if (employee == null || !employee.Active)
                return false;
            bool isValid = VerifyPassword(password, employee.Password);

            //save last login date
            if (isValid)
            {
                employee.LastLoginDateUtc = DateTime.UtcNow;
                _employeeService.Update(employee);
            }

            return isValid;
        }

        //public CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest request)
        //{
        //    if (request == null)
        //        throw new ArgumentNullException("request");

        //    if (request.Customer == null)
        //        throw new ArgumentException("Can't load current customer");

        //    var result = new CustomerRegistrationResult();
        //    if (String.IsNullOrEmpty(request.Email))
        //    {
        //        result.AddError("Email is not provided");
        //        return result;
        //    }
        //    if (!CommonHelper.IsValidEmail(request.Email))
        //    {
        //        result.AddError("Wrong email");
        //        return result;
        //    }
        //    if (String.IsNullOrWhiteSpace(request.Password))
        //    {
        //        result.AddError("Password Is Not Provided");
        //        return result;
        //    }
    
        //    //validate unique user
        //    if (_customerService.GetCustomerByUserName(request.ProgramId,request.Email) != null)
        //    {
        //        result.AddError("Email Already Exists");
        //        return result;
        //    }

        //    //at this point request is valid
        //    request.Customer.ProgramId = request.ProgramId;
        //    request.Customer.UserName = request.Username;
        //    request.Customer.Email = request.Email;
          
        //    request.Customer.Password = EncryptPassword(request.Password);
        //    request.Customer.Active = request.IsApproved;
        //    request.Customer.Deleted = false;
   

        //    request.Customer.CreatedOnUtc = DateTime.UtcNow;
        //    request.Customer.LastActivityDateUtc = DateTime.UtcNow;


        //    _customerService.InsertCustomer(request.Customer);
        //    return result;
        //}

        //public virtual PasswordChangeResult ChangePassword(ChangePasswordRequest request)
        //{
        //    if (request == null)
        //        throw new ArgumentNullException("request");

        //    var result = new PasswordChangeResult();
        //    if (String.IsNullOrWhiteSpace(request.Email))
        //    {
        //        result.AddError("Email Is Not Provided");
        //        return result;
        //    }
        //    if (String.IsNullOrWhiteSpace(request.NewPassword) || String.IsNullOrWhiteSpace(request.NewPasswordConfirm))
        //    {
        //        result.AddError("Please enter old and new passwords");
        //        return result;
        //    }
        //    if (request.NewPassword != request.NewPasswordConfirm)
        //    {
        //        result.AddError("New Password and Confirm New Password do not match");
        //        return result;
        //    }

        //    var customer = _customerService.GetCustomerByUserName(request.ProgramId, request.Email);
        //    if (customer == null)
        //    {
        //        result.AddError("Email Not Found");
        //        return result;
        //    }


        //    var requestIsValid = false;
        //    if (request.ValidateRequest)
        //    {
        //        //password
        //        var oldPwd = request.OldPassword;
        //        var oldPasswordIsValid = VerifyPassword(oldPwd, customer.Password);
        //        if (!oldPasswordIsValid)
        //            result.AddError("Old password doesn't match");

        //        if (oldPasswordIsValid)
        //            requestIsValid = true;
        //    }
        //    else
        //        requestIsValid = true;


        //    //at this point request is valid
        //    if (requestIsValid)
        //    {
        //        customer.Password = EncryptPassword(request.NewPassword);
        //        _customerService.UpdateCustomer(customer);
        //    }

        //    return result;
        //}


        public string EncryptPassword(string password)
        {
            return _encryptionService.EncryptPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {   
            #if DEBUG
                return true;
            #endif
 
            return _encryptionService.VerifyPassword(password, hashedPassword);
        }

        #endregion
    }
}