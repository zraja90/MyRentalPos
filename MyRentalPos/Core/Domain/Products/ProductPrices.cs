﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRentalPos.Core.Domain.Products
{
    public class ProductPrices : BaseEntity
    {
        public int DayPrice { get; set; }
        public int WeeklyPrice { get; set; }
    }
}