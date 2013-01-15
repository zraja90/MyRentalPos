using System.Web.Mvc;
using MyRentalPos.Areas.Admin.Models.Store;
using MyRentalPos.Core;
using MyRentalPos.Helpers;
using MyRentalPos.Services.Security;
using MyRentalPos.Services.Stores;

namespace MyRentalPos.Controllers
{
    
    public class StoreController : Controller
    {
        private readonly IWebHelper _webHelper;
        private readonly IPermissionService _permissionService;
        private readonly IStoreService _storeService;
        public StoreController(IWebHelper webHelper,IPermissionService permissionService, IStoreService storeService)
        {
            _webHelper = webHelper;
            _permissionService = permissionService;
            _storeService = storeService;
        }

        //
        // GET: /Admin/StoreController/

        public ActionResult Index(string returnUrl = "")
        {
            var host = _webHelper.GetHost(false);

            var store = _storeService.Get(x => x.BaseUrl == host && x.IsActive);
            if (store != null)
            {
                StoreHelper.SetStoreUrlToCookie(host);
                StoreHelper.SetStoreIdToCookie(store.Id);
                //StoreHelper.SetStoreThemeToCookie(store.Theme == null ? "" : store.Theme.Name);

                if (string.IsNullOrEmpty(returnUrl))
                    returnUrl = "/";
                returnUrl = Server.UrlDecode(returnUrl);
                return Redirect(returnUrl);
            }
            return RedirectToAction("Error", "Error");
        }
    }
}
