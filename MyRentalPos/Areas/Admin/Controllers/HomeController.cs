using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRentalPos.Areas.Admin.Models;
using MyRentalPos.Filters;
using MyRentalPos.Helpers;

namespace MyRentalPos.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

     
        
    }
}
