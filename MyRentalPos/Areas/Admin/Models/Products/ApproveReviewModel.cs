using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Products;

namespace MyRentalPos.Areas.Admin.Models.Products
{
    public class ApproveReviewModel
    {
        public IList<ProductReviews> Reviews { get; set; }
    }
}