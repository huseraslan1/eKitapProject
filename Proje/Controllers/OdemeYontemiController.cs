using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
   
    public class OdemeYontemiController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult Ekle()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Ekle(OdemeYontemi data)
        {
            db.OdemeYontemis.Add(data);
            int sonuc = db.SaveChanges();

            if (sonuc==1)
            {
                TempData["sonuc"] = 1;
            }

            return RedirectToAction("Liste");
        }

        public ActionResult Liste()
        {

            var odemeYontemleri = db.OdemeYontemis.ToList();

            return View(odemeYontemleri);
        }

        public ActionResult Sil(int id)
        {
            try
            {
                var silinecekOdeme = db.OdemeYontemis.Find(id);

                db.OdemeYontemis.Remove(silinecekOdeme);

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


        public ActionResult Guncelle(int id)
        {
            try
            {
                var guncellenecekOdeme = db.OdemeYontemis.Where(x => x.Id == id).FirstOrDefault();

                return View(guncellenecekOdeme);
            }
            catch (Exception)
            {

                return RedirectToAction("Liste");
            }
        }

        [HttpPost]
        public ActionResult Guncelle(OdemeYontemi data)
        {
            try
            {
                var guncellenecekOdeme = db.OdemeYontemis.Where(x => x.Id == data.Id).FirstOrDefault();

                guncellenecekOdeme.Aciklama = data.Aciklama;
                guncellenecekOdeme.Tanim = data.Tanim;

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