using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Data;

namespace MyRentalPos.Services.CustomerService
{
    public class EmailSubscriptionService: CrudService<EmailSubscription>, IEmailSubscriptionService
    {
        public EmailSubscriptionService(IRepository<EmailSubscription> repo) : base(repo)
        {
        }
    }
}