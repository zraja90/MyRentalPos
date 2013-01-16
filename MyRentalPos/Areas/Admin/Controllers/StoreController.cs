using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRentalPos.Areas.Admin.Models.Store;
using MyRentalPos.Core.Domain.Stores;
using MyRentalPos.Filters;
using MyRentalPos.Mappers;
using MyRentalPos.Services.Stores;

namespace MyRentalPos.Areas.Admin.Controllers
{
    //[AdminAuthorize]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        //
        // GET: /Admin/Store/

        public ActionResult Index()
        {
            var model = new AllStoresModel();
            model.Stores = _storeService.GetAll();

            return View(model);
        }



        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/StoreController/Create

        public ActionResult Create()
        {
            var model = new CreateStoreModel();
            return View(model);
        }

        //
        // POST: /Admin/StoreController/Create

        [HttpPost]
        public ActionResult Create(CreateStoreModel model)
        {
            try
            {
                var entity = model.ToEntity();
                
                _storeService.Add(entity);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                
                return View();
            }
        }

        //
        // GET: /Admin/StoreController/Edit/5

        public ActionResult Edit(int id)
        {
            var model = new EditStoreModel();
            model.Store = _storeService.GetById(id);
            return View(model);
        }

        //
        // POST: /Admin/StoreController/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/StoreController/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/StoreController/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

    public class EditStoreModel
    {
        public Store Store { get; set; }
    }
}
