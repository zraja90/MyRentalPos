using MyRentalPos.Core.Domain.Customers;

namespace MyRentalPos.Services.Authentication
{
    public partial interface IAuthenticationService
    {
        void Login(Customer customer, bool persistentCookie);
        void Logout();
        Customer GetAuthenticatedCustomer();
    }
}
