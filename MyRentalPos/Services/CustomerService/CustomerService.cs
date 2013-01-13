using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Data;

namespace MyRentalPos.Services.CustomerService
{
    /// <summary>
    /// Customer service
    /// </summary>
    public partial class CustomerService : CrudService<Customer>, ICustomerService
    {
        #region Ctor

        private readonly IRepository<Customer> _customerRepository; 
        public CustomerService(IRepository<Customer> customerRepository)
            : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

      
    }
}