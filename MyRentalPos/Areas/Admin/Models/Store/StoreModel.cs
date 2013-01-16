using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyRentalPos.Areas.Admin.Models.Store
{
    public class StoreModel
    {
        public StoreModel()
        {
            IsGlobal = false;
            CreatedDate = DateTime.UtcNow;
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

        public int StoreId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}