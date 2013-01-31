using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRentalPos.Areas.Admin.Models.Common;
using MyRentalPos.Areas.Admin.Models.Store;
using MyRentalPos.Core;
using MyRentalPos.Core.Domain.Employees;
using MyRentalPos.Core.Domain.Stores;
using MyRentalPos.Filters;
using MyRentalPos.Filters.Helpers;
using MyRentalPos.Mappers;
using MyRentalPos.Services.Stores;
using Newtonsoft.Json;

namespace MyRentalPos.Areas.Admin.Controllers
{
    //[AdminAuthorize]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IWorkContext _workContext;
        public StoreController(IStoreService storeService, IWorkContext workContext)
        {
            _storeService = storeService;
            _workContext = workContext;
        }

        public ActionResult Index()
        {
            var model = new AllStoresModel();
            model.Stores = _storeService.GetAll().ToList();


            return View(model);
        }


        [ChildActionOnly]
        public ActionResult LeftMenu()
        {
            var model = new LeftMenuModel
            {
                IsLoggedIn = _workContext.IsLoggedIn,
                Employee = _workContext.CurrentEmployee,
                Store = _workContext.CurrentStore
            };
            return PartialView(model);
        }
       

        public ActionResult Create()
        {
            var stores = _storeService.GetAll().ToList();
            var model = new CreateStoreModel
            {
                StoreAddress = new StoreAddressModel(),
                Store = new StoreModel(),
                Urls = stores.Select(x => x.BaseUrl),
            };
            model.JsonModel = JsonConvert.SerializeObject(model);   
            //Create a cookie with store id in case refresh is hit. 
            return View(model);
        }
        [HttpPost]
        public JsonResult CreateStoreJson(StoreModel model)
        {
            if (ModelState.IsValid)
            {
                model.LogOutUrl = model.BaseUrl;
                var entity = model.ToEntity();
                _storeService.Add(entity);
                return Json(new {success = true,storeId = entity.Id});
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public JsonResult CreateStoreAddressJson(StoreAddressModel model)
        {
            if(ModelState.IsValid)
            {
                var entity = model.ToEntity();
                _storeService.AddAddress(entity);
                return Json(new {success = true});
            }
            return Json(new { success = false });
        }

        public ActionResult Edit(int id)
        {
            var entity = _storeService.GetById(id);
            //var model = entity;
            var address = entity.StoreAddress;

            //model.Address = address.Address;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(StoreModel model)
        {
            try
            {
                //var entity = model.ToEntity();

                //if (string.IsNullOrEmpty(entity.LogOutUrl))
                //  entity.LogOutUrl = model.BaseUrl;
                //    _storeService.AddOrUpdate(entity);


                //  this.SuccessNotification(entity.StoreName + " has been updated");

                return RedirectToAction("Index");
            }
            catch
            {
                this.ErrorNotification("There was an error in updating. Please check the information entered and submit again");
                return View();
            }
        }
    }
}
