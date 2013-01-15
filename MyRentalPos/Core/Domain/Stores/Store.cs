using System;
using System.Collections.Generic;
using MyRentalPos.Core.Domain.Customers;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Core.Domain.Products;
using MyRentalPos.Core.Domain.Order;

namespace MyRentalPos.Core.Domain.Stores
{
    public class Store : BaseEntity
    {
        private ICollection<Employee> _employees;
        private ICollection<StoreAddress> _storeAddress;
        private ICollection<Customer> _customers;
        private ICollection<Product> _products;
        private ICollection<Orders> _orders;

        public string StoreName { get; set; }
        public string BaseUrl { get; set; }
        public string LogOutUrl { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public bool IsGlobal { get; set; }
        public string Owner { get; set; }
        public string Email { get; set; }
        public DateTime CreateDated { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get { return _employees ?? (_employees = new List<Employee>()); }
            protected set { _employees = value; }
        }

        public virtual ICollection<StoreAddress> StoreAddress
        {
            get { return _storeAddress ?? (_storeAddress = new List<StoreAddress>()); }
            protected set { _storeAddress = value; }
        }
        public virtual ICollection<Customer> Customer
        {
            get { return _customers ?? (_customers = new List<Customer>()); }
            protected set { _customers = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return _products ?? (_products = new List<Product>()); }
            protected set { _products = value; }
        }

        public virtual ICollection<Orders> Orders
        {
            get { return _orders ?? (_orders = new List<Orders>()); }
            protected set { _orders = value; }
        }
    }
}