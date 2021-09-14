using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
    
    public class HomeController : Controller
    {
        
        
        public ActionResult Index()
        {

            //if (Request.Cookies["Eposta"]==null)
            //{
            //    return RedirectToAction("Index", "Giris");
            //}
            //else
            //{
            //    ViewBag.Eposta = Request.Cookies["Eposta"].Value;
            //}

            return View();
        }

        public PartialViewResult Durum()
        {

            return PartialView(new Durum().durumModel());
        }
    }
}