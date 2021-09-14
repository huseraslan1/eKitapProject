using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
   
    public class KargoController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Ekle(KargoFirmasi data)
        {
            db.KargoFirmasis.Add(data);
            int sonuc = db.SaveChanges();

            if (sonuc == 1)
            {
                TempData["sonuc"] = 1;
            }
            return RedirectToAction("Ekle");
        }

        public ActionResult Liste()
        {
            var kargo = db.KargoFirmasis.ToList();
            return View(kargo);
        }

        public ActionResult Sil(int id)
        {
            try
            {
                var silinecekKargo = db.KargoFirmasis.Find(id);
                db.KargoFirmasis.Remove(silinecekKargo);
                int sonuc = db.SaveChanges();

                if (sonuc == 1)
                {
                    TempData["sonuc"] = 1;
                }
                return RedirectToAction("Liste");
            }
            catch (Exception)
            {

                return RedirectToAction("Liste");
            }
        }

        public ActionResult Guncelle(int id)
        {
            try
            {
                var kargoFirmasi = db.KargoFirmasis.Where(x => x.Id == id).FirstOrDefault();
                return View(kargoFirmasi);
            }
            catch (Exception)
            {

                return RedirectToAction("Liste");
            }
        }

        [HttpPost]

        public ActionResult Guncelle(KargoFirmasi data)
        {
            try
            {
                var guncellenecekKargo = db.KargoFirmasis.Where(x => x.Id == data.Id).FirstOrDefault();

                guncellenecekKargo.Adres = data.Adres;
                guncellenecekKargo.Eposta = data.Eposta;
                guncellenecekKargo.Sirket = data.Sirket;
                guncellenecekKargo.Telefon = data.Telefon;
                guncellenecekKargo.WebSitesi = data.WebSitesi;

                int sonuc = db.SaveChanges();
                if (sonuc==1)
                {
                    TempData["sonuc"] = 1;
                }
                return RedirectToAction("Liste");
            }
            catch (Exception)
            {

                return RedirectToAction("Liste");
            }
        }
    }
}