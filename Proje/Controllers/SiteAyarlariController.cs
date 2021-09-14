using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
   
    public class SiteAyarlariController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult Ekle()
        {
            ViewBag.seo = db.Seos.ToList();
            ViewBag.siteAyarlari = db.SiteAyarlaris.ToList();
            ViewBag.mailAyarlari = db.MailAyarlaris.ToList();


            return View("Ekle");
        }
        [HttpPost]

        public ActionResult Seo(Seo data)
        {
            Seo guncellenecekseo = db.Seos.Where(x=>x.Id==1).FirstOrDefault();

            guncellenecekseo.Baslik = data.Baslik;
            guncellenecekseo.AnahtarKelime = data.AnahtarKelime;
            guncellenecekseo.Harita = data.Harita;
            guncellenecekseo.Isım = data.Isım;
            int sonuc = db.SaveChanges();

            if (sonuc==1)
            {
                TempData["sonuc"] = 1;
                
            }
            return RedirectToAction("Ekle");
        }

        public ActionResult SiteAyarlari(SiteAyarlari data)
        {
            SiteAyarlari guncellenecekSiteAyarlari = db.SiteAyarlaris.Where(x => x.Id == 1).FirstOrDefault();

            guncellenecekSiteAyarlari.Adres = data.Adres;
            guncellenecekSiteAyarlari.Eposta = data.Eposta;
            guncellenecekSiteAyarlari.Telefon = data.Telefon;

            int sonuc = db.SaveChanges();

            if (sonuc == 1)
            {
                TempData["sonuc"] = 1;

            }
            return RedirectToAction("Ekle");
        }

        public ActionResult MailAyarlari(MailAyarlari data)
        {
            MailAyarlari guncellenecekMailAyar = db.MailAyarlaris.Where(x => x.Id == 1).FirstOrDefault();

            guncellenecekMailAyar.Eposta = data.Eposta;
            guncellenecekMailAyar.EpostaSifresi = data.EpostaSifresi;
            guncellenecekMailAyar.GondericiBilgisi = data.GondericiBilgisi;
            guncellenecekMailAyar.MailGonderici = data.MailGonderici;
            guncellenecekMailAyar.Smtp_port = data.Smtp_port;
            guncellenecekMailAyar.Smtp_server = data.Smtp_server;
            int sonuc = db.SaveChanges();

            if (sonuc == 1)
            {
                TempData["sonuc"] = 1;

            }
            return RedirectToAction("Ekle");
        }
    }
}