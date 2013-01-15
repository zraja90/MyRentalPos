using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Data;

namespace MyRentalPos.Services.Employees
{
    public class EmployeeService : CrudService<Employee>, IEmployeeService
    {
        public EmployeeService(IRepository<Employee> repo) : base(repo)
        {
        }

        public Employee GetCustomerByUserName(string userName)
        {
            return repo.Get(x => x.UserName == userName);
        }
    }
}