using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;

namespace MyRentalPos.Services.Authentication
{
    public partial interface IAuthenticationService
    {
        void Login(Employee employee, bool persistentCookie);
        void Logout();
        Employee GetAuthenticatedEmployee();
    }
}
