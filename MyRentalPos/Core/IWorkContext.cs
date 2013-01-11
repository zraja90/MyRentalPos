using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Core
{
    public interface IWorkContext
    {
        Employee CurrentEmployee { get; set; }
        Store CurrentStore { get; set; }
        bool IsLoggedIn { get; }
        string LogoutUrl { get; }
        int StoreId { get; }
    }
}
