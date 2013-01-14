using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Data;

namespace MyRentalPos.Services.CustomerService
{
    /// <summary>
    /// Customer service
    /// </summary>
    public partial class CustomerService : CrudService<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repo) : base(repo)
        {
        }
    }
}