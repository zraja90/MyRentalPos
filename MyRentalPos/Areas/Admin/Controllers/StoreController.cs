using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            //var model = new AllStoresModel { Stores = _storeService.GetAll() };

            return View();
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
        public class LeftMenuModel
        {
            public bool IsLoggedIn { get; set; }
            public Employee Employee { get; set; }
            public Store Store { get; set; }
        }

        public ActionResult Create()
        {
            var stores = _storeService.GetAll().ToList();
            var model = new CreateStoreModel
            {
                StoreAddress = new List<StoreAddressModel>(),
                Store = new StoreModel(),
                Urls = stores.Select(x => x.BaseUrl),
            };
            model.JsonModel = JsonConvert.SerializeObject(model);
            

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(StoreModel model)
        {
            try
            {
                //var storeEntity = model;
                //storeEntity.LogOutUrl = model.BaseUrl;
                //_storeService.Add(storeEntity);
                //var addressEntity = new StoreAddress
                //                        {
                //                            Address = model.Address,
                //                            City = model.City,
                //                            State = model.State,
                //                            StoreId = storeEntity.Id,
                //                            PhoneNumber = model.PhoneNumber,
                //                            ZipCode = model.ZipCode,
                //                            FaxNumber = model.FaxNumber,
                //                            Country = model.Country
                //                        };
                ////storeEntity.StoreAddress = addressEntity;
                //_storeService.Update(storeEntity);
                this.SuccessNotification("Store was created.");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.ErrorNotification("There was an error in creating the store. Please try again.");
                return View();
            }
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
