using System;
using System.Collections.Generic;

namespace MyRentalPos.Core.Domain.Customers
{
    public class Customer : BaseEntity
    {
        public int StoreId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        private ICollection<CustomerBillingInfo> _customerBillingInfos;
        private ICollection<CustomerShippingInfo> _customerShippingInfos;

        public virtual ICollection<CustomerBillingInfo> CustomerBillingInfos
        {
            get { return _customerBillingInfos ?? (_customerBillingInfos = new List<CustomerBillingInfo>()); }
            protected set { _customerBillingInfos = value; }
        }
        public virtual ICollection<CustomerShippingInfo> CustomerShippingInfos
        {
            get { return _customerShippingInfos ?? (_customerShippingInfos = new List<CustomerShippingInfo>()); }
            protected set { _customerShippingInfos = value; }
        }
    }
}
