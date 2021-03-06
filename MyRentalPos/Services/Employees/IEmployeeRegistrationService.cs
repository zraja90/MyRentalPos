namespace MyRentalPos.Services.Employees
{
    /// <summary>
    /// Customer registration interface
    /// </summary>
    public partial interface IEmployeeRegistrationService
    {
        bool ValidateEmployee(string username, string password);

        //CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest request);

        //PasswordChangeResult ChangePassword(ChangePasswordRequest request);

        string EncryptPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}