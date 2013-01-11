using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Data;

namespace MyRentalPos.Services.CustomerService
{
    public class ContactUsService :CrudService<ContactUs>, IContactUsService
    {
        public ContactUsService(IRepository<ContactUs> repo) : base(repo)
        {
        }
    }
}