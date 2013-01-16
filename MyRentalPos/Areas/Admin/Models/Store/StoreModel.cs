using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Areas.Admin.Models.Store
{
    public class StoreModel
    {
        public StoreModel()
        {
            IsGlobal = false;
            CreatedDate = DateTime.UtcNow;
            //Country = "USA";
        }
        public int Id { get; set; }
        [Required]
        [DisplayName("Store Name")]
        public string StoreName { get; set; }
        [Required]
        [DisplayName("Store URL")]
        public string BaseUrl { get; set; }
        public string LogOutUrl { get; set; }
        [Required]
        [DisplayName("Store Logo")]
        public string Image { get; set; }
        [Required]
        [DisplayName("Is Store Active?")]
        public bool IsActive { get; set; }
        [DisplayName("Global Store?")]
        public bool IsGlobal { get; set; }
        [Required]
        [DisplayName("Store Owner")]
        public string Owner { get; set; }
        [Required]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        public DateTime CreatedDate { get; set; }
        //public int StoreId { get; set; }
        //[Required]
        //[DisplayName("Address")]
        //public string Address { get; set; }
        //[Required]
        //[DisplayName("City")]
        //public string City { get; set; }
        //[Required]
        //[DisplayName("State")]
        //public string State { get; set; }
        //[Required]
        //[DisplayName("Zip Code")]
        //public string ZipCode { get; set; }
        //[Required]
        //[DisplayName("Country")]
        //public string Country { get; set; }
        //[Required]
        //[DisplayName("Primary Phone Number")]
        //public string PhoneNumber { get; set; }
        
        //[DisplayName("Primary Fax Number")]
        //public string FaxNumber { get; set; }
    }
    public class CreateStoreModel
    {
        public Core.Domain.Stores.Store Store { get; set; }
        public List<StoreAddress> StoreAddress { get; set; }
        public string JsonModel { get; set; }
    }
}