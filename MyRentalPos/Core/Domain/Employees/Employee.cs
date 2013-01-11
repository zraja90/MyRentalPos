using System;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Core.Domain.Employees
{
    public class Employee : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}