using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRentalPos.Core.Domain.Customers;

namespace MyRentalPos.Core
{
    public interface IWorkContext
    {
        Customer CurrentCustomer { get; set; }
        bool IsLoggedIn { get; }
        string LogoutUrl { get; }
    }
}
