using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRentalPos.Core.Domain.Employees;

namespace MyRentalPos.Services.Employees
{
    public interface IEmployeeService : ICrudService<Employee>
    {
        Employee GetCustomerByUserName(string userName);
    }
}
