using Arayuz.repository;
using Arayuz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KullaniciKismi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

       

        public PartialViewResult KitapListesi()
        {
            KitapRepository kitapRepository = new KitapRepository();
            var liste = kitapRepository.listeGetir();
            return PartialView(liste);
        }

   

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult IadeKosullari()
        {
            return View();
        }
        public ActionResult GizlilikIlkesi()
        {
            return View();
        }
        public ActionResult UyeSozlesmesi()
        {
            return View();
        }

    }
}