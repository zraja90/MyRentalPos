using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRentalPos.Core.Domain.Products
{
    public class RentalPrices : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public EnumRentalType RentalType { get; set; }
        public int Price { get; set; }
    }
}