using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Products;

namespace MyRentalPos.Areas.Admin.Models
{
    public class AllProductsListModel
    {
        public IList<Product> Products { get; set; }
        public IList<ProductCategory> AllCategories { get; set; }
    }
}