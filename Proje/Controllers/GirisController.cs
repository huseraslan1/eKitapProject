using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Proje.Controllers
{
    
    public class GirisController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Giris data)
        {
            Giris giris = db.Giris.Where(x =>x.Eposta == data.Eposta && x.Sifre == data.Sifre).FirstOrDefault();

            if (giris == null)
            {
                ViewBag.mesaj = "Kullanıcı Adı veya Şifreniz Yanlış.";
                return View("Index");
            }
            else
            {
                if (giris.Adminmi == true)
                {
                    FormsAuthentication.SetAuthCookie(giris.Eposta, true);

                    HttpCookie cerez = new HttpCookie("Eposta",giris.Eposta);
                    cerez.Expires.AddDays(2);
                    Response.Cookies.Add(cerez);

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    TempData["sonuç"] = 0;
                    return View("Index");
                }
            }
        }

        public ActionResult CikisYap()
        {
            Response.Cookies["Eposta"].Expires = DateTime.Now.AddDays(-2);
            FormsAuthentication.SignOut();

            return RedirectToAction("Index","Giris");
        }


    }
}