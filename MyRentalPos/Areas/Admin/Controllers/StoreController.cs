using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRentalPos.Areas.Admin.Models.Store;

namespace MyRentalPos.Areas.Admin.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Admin/Store/

        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                //return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/StoreController/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
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
}
