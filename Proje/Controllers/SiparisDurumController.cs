using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
  
    public class SiparisDurumController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Ekle(SiparisDurumu data)
        {

            try
            {

                db.SiparisDurumus.Add(data);
                int sonuc = db.SaveChanges();

                if (sonuc == 1)
                {
                    TempData["sonuc"] = 1;
                }

                return RedirectToAction("Liste");

            }
            catch (Exception)
            {

                return RedirectToAction("Ekle");

            }
        }

        public ActionResult Liste()
        {
            var liste = db.SiparisDurumus.ToList();

            return View(liste);
        }

        public ActionResult Sil(int id)
        {

            try
            {
                var silinecekdurum = db.SiparisDurumus.Find(id);
                db.SiparisDurumus.Remove(silinecekdurum);

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

            var guncelencekdurum = db.SiparisDurumus.Where(x => x.Id == id).FirstOrDefault();
            return View(guncelencekdurum);
        }

        [HttpPost]
        public ActionResult Guncelle(SiparisDurumu data)
        {

            try
            {
                var guncelenecekdurum = db.SiparisDurumus.Where(x => x.Id == data.Id).FirstOrDefault();

                guncelenecekdurum.Tanim = data.Tanim;
                guncelenecekdurum.Detay = data.Detay;
                db.SaveChanges();


                return RedirectToAction("Liste");
            }
            catch (Exception)
            {

                return RedirectToAction("Liste");
            }
        }
    }
}