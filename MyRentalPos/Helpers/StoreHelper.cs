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
        private const string StoreCookieName = "storename";
        private const string StoreCookieUrl = "storeurl";
        private const string StoreCookieTheme = "storetheme";

        public static void SetStoreIdToCookie(int programId)
        {
            CookieHelper.SetCookie(StoreCookieName, programId.ToString());
        }

        public static int GetStoreIdFromCookie()
        {
            var result = 0;

            var cookieValue = CookieHelper.GetCookie(StoreCookieName);
            if (!string.IsNullOrEmpty(cookieValue))
                result = CommonHelper.To<int>(cookieValue);
            return result;
        }

        public static void SetStoreUrlToCookie(string url)
        {
            CookieHelper.SetCookie(StoreCookieUrl, url);
        }

        public static string GetStoreUrlFromCookie()
        {
            var result = "";

            var cookieValue = CookieHelper.GetCookie(StoreCookieUrl);
            if (!string.IsNullOrEmpty(cookieValue))
                result = cookieValue;
            return result;

        }

        public static void SetStoreThemeToCookie(string themeName)
        {
            if (!string.IsNullOrWhiteSpace(themeName) && !themeName.StartsWith("-"))
            {
                themeName = "-" + themeName;
            }

            CookieHelper.SetCookie(StoreCookieTheme, themeName);
        }

        public static string GetStoreThemeFromCookie()
        {
            var result = "";

            var cookieValue = CookieHelper.GetCookie(StoreCookieTheme);
            if (!string.IsNullOrEmpty(cookieValue))
            {
                result = cookieValue;
            }
            return result;
        }

        public static bool IsSameHost(string url)
        {
            bool result = false;

            var cookieUrl = GetStoreUrlFromCookie();
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(cookieUrl))
            {
                if (url.ToLower() == cookieUrl.ToLower())
                    result = true;
            }
            return result;

        }

        private static string FormatHost(string url)
        {
            if (string.IsNullOrEmpty(url))
                return "";

            var result = url;
            result = result.Trim();
            result = result.Replace("http:\\", "");
            result = result.Replace("https:\\", "");
            if (result.EndsWith("/") && result.Length > 1)
                result = result.Substring(0, result.Length - 1);
            result = result.ToLower();

            return result;
        }
    }
}