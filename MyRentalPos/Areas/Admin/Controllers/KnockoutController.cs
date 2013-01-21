using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRentalPos.Areas.Admin.Models.Store;
using MyRentalPos.Mappers;
using MyRentalPos.Services.Stores;

namespace MyRentalPos.Areas.Admin.Controllers
{
    public class KnockoutController : Controller
    {
        private readonly IStoreService _storeService;
        public KnockoutController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        //
        // GET: /Admin/Knockout/
        

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Knockout/Details/5

        public ActionResult Details()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CreateStoreJson(StoreModel model)
        {
            var success = "";
            try
            {
                model.LogOutUrl = model.BaseUrl;
                var entity = model.ToEntity();
                _storeService.Add(entity);
                success = "Brochure Updated";
            }
            catch (Exception)
            {
                success = "Update Failed";
            }

            return Json(success);
        }

        //
        // GET: /Admin/Knockout/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Knockout/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Knockout/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Knockout/Edit/5

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
        // GET: /Admin/Knockout/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Knockout/Delete/5

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
}
