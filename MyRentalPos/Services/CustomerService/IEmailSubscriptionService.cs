using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRentalPos.Core.Domain.Customers;

namespace MyRentalPos.Services.CustomerService
{
    public interface IEmailSubscriptionService:ICrudService<EmailSubscription>
    {
    }
}
