using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyRentalPos.Core.Domain.Products
{
    public enum EnumRentalType
    {
        [Description("Daily")]
        Daily =0,
        [Description("Weekly")]
        Weekly =1,
        [Description("Bi-Weekly")]
        BiWeekly =2,
        [Description("Monthly")]
        Monthly=3,
        [Description("Yearly")]
        Yearly=4
    }
}