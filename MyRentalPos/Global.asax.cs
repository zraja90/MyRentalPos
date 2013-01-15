using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyRentalPos.App_Start;
using MyRentalPos.Core;
using MyRentalPos.Helpers;
using MyRentalPos.Services.Tasks;

namespace MyRentalPos
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            AutofacConfig.RegisterAutofac();
            AutoMapperConfig.Configure();


            TaskManager.Instance.Initialize();
            TaskManager.Instance.Start();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var webHelper = DependencyResolver.Current.GetService<IWebHelper>();
            var host = webHelper.GetApplicationUrl(false);
            var isStaticResource = webHelper.IsStaticResource(this.Request);
            var thisPageUrl = webHelper.GetThisPageUrl(false);
            string storeUrl = string.Format("{0}Store/", host);
            string errorUrl = string.Format("{0}Error/", host);


            Debug.WriteLine(string.Format("urls:store->{0}:error->{1}:host->{2}:static->{3}:page->{4} ", storeUrl, errorUrl, host, isStaticResource, thisPageUrl));


            if (!isStaticResource &&
                !StoreHelper.IsSameHost(host) &&
                !thisPageUrl.StartsWith(storeUrl, StringComparison.InvariantCultureIgnoreCase) &&
                !thisPageUrl.StartsWith(errorUrl, StringComparison.InvariantCultureIgnoreCase)
                )
            {
                var returnUrl = Server.UrlEncode(Request.Url.ToString());
                storeUrl = storeUrl + "?returnurl=" + returnUrl;
                Debug.WriteLine(string.Format("urls:store->{0}:return->{1}", storeUrl,returnUrl));
                this.Response.Redirect(storeUrl);
            }
        }
    }
}