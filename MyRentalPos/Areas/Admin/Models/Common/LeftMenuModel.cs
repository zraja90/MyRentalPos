using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Core.Domain.Stores;

namespace MyRentalPos.Areas.Admin.Models.Common
{
    public class LeftMenuModel
    {
        public bool IsLoggedIn { get; set; }
        public Employee Employee { get; set; }
        public Core.Domain.Stores.Store Store { get; set; }
    }
}