using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRentalPos.Core.Domain.Products
{
    public class Product : BaseEntity
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RentalQuantity { get; set; }
        public int SalesQuantity { get; set; }
        public bool IsRental { get; set; }
        public bool IsSales { get; set; }
        public int SalesPrice { get; set; }
        
        private ICollection<RentalPrices> _rentalPrices;

        public virtual ICollection<RentalPrices> RentalPrices
        {
            get { return _rentalPrices ?? (_rentalPrices = new List<RentalPrices>()); }
            protected set { _rentalPrices = value; }
        }
    }
}