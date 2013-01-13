using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRentalPos.Core;
using MyRentalPos.Core.Common;

namespace MyRentalPos.Helpers
{
    public class StoreHelper
    {
        private const string StoreCookieName = "pcname";
        public static int GetStoreIdFromCookie()
        {
            var result = 0;
            var cookieValue = CookieHelper.GetCookie(StoreCookieName);
            if (!string.IsNullOrEmpty(cookieValue))
                result = CommonHelper.To<int>(cookieValue);
            return result;
        }
    }
}