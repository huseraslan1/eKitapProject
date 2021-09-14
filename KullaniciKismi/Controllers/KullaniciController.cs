 using Arayuz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KullaniciKismi.Controllers
{
    public class KullaniciController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();

        public ActionResult Index()
        {
            if (Request.Cookies["kullaniciAdi"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (Session["uyeid"]!=null)
                {
                    ViewBag.username = Session["uyeid"].ToString();
                }
                else
                {
                    TempData["sonuc"] = 0;
                }
            }
            return View();
        }

        public ActionResult Guncelle(int? id)
        {
            try
            {
                if (id==null)
                {
                    return RedirectToAction("Index", "Home");
                }
                var musteriguncelle = db.Musteri.Where(x => x.Id == id).FirstOrDefault();

                if (musteriguncelle==null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(musteriguncelle);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Guncelle(Musteri data)
        {
            Musteri guncellenecek = db.Musteri.FirstOrDefault(x => x.Id == data.Id);
            guncellenecek.Adi = data.Adi;
            guncellenecek.Soyadi = data.Soyadi;
            guncellenecek.Eposta = data.Eposta;
            guncellenecek.TeslimatAdresi = data.TeslimatAdresi;
            int sonuc = db.SaveChanges();
            if (sonuc==1)
            {
                TempData["sonuc"] = 3;
            }
            else
            {
                TempData["sonuc"] = 4;
            }
            return View(guncellenecek);
        }

        public ActionResult SifreGuncelle(int? id)
        {
            try
            {
                if (id==null)
                {
                    return View("Index");
                }
                var sifreguncelle = db.Musteri.Where(x => x.Id == id).FirstOrDefault();

                if (sifreguncelle==null)
                {
                    return View("Index");
                }
                return View(sifreguncelle);
            }
            catch (Exception)
            {

                return View("Index");
            }
        }

        [HttpPost]

        public ActionResult SifreGuncelle(Musteri data)
        {
            try
            {
                Musteri sifreguncelle = db.Musteri.FirstOrDefault(x=>x.Id==data.Id);
                sifreguncelle.Sifre = data.Sifre;
                db.SaveChanges();
                return RedirectToAction("sifreguncelle");

            }
            catch (Exception)
            {

                return RedirectToAction("sifreguncelle");
            }
        }
    }
}