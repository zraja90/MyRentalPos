using MyRentalPos.Core.Domain.Customers;

namespace MyRentalPos.Services.CustomerService
{
    public partial interface ICustomerService : ICrudService<Customer>
    {
        Customer GetCustomerByUserName(string email);
    }
}