using Proje.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{

    
    public class YayinEvleriController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult Ekle()
        {
            ViewBag.kitap = db.Kitaplars.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(YayinEvleri data)
        {
            if (ModelState.IsValid)
            {
                db.YayinEvleris.Add(data);

                int sonuc = db.SaveChanges();

                if (sonuc == 1)
                {
                    TempData["sonuc"] = 1;
                }

            }

            return RedirectToAction("Liste");
        }

        public ActionResult Liste()
        {
            try
            {
                var liste = db.YayinEvleris.ToList();
                return View(liste);
            }
            catch (Exception)
            {

                return View("Ekle");
            }
        }

        public PartialViewResult YayinEviListe()
        {
            var liste = db.YayinEvleris.ToList();
            return PartialView(liste);
        }

        public ActionResult Sil(int id)
        {
            YayinEvleri silinecekYayinEvi = (from x in db.YayinEvleris where x.Id == id select x).FirstOrDefault();
            return View(silinecekYayinEvi);
        }

        [HttpPost, ActionName("Sil")]

        public ActionResult SilmeIslemi(int id)
        {
            YayinEvleri silinecekYayinEvi = (from x in db.YayinEvleris where x.Id == id select x).FirstOrDefault();

            db.YayinEvleris.Remove(silinecekYayinEvi);

            
            int sonuc = db.SaveChanges();

            if (sonuc==1)
            {
                TempData["sonuc"] = 1;

            }
            return RedirectToAction("Liste");
        }

        public ActionResult Guncelle(int id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Liste");
                }
                var guncellenecekYayinEvi = db.YayinEvleris.Where(x => x.Id == id).FirstOrDefault();

                if (guncellenecekYayinEvi == null)
                {
                    TempData["sonuc"] = 0;

                    return RedirectToAction("Guncelle");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Guncelle(YayinEvleri data) 
        {
            try
            {
                YayinEvleri guncellenecek = db.YayinEvleris.FirstOrDefault(x => x.Id == data.Id);

                guncellenecek.Tanim = data.Tanim;

                int sonuc = db.SaveChanges();

                if (sonuc == 1)
                {
                    TempData["sonuc"] = 1;
                }
                else
                {
                    TempData["sonuc"] = 0;
                }
                return RedirectToAction("Liste");
            }
            catch (Exception)
            {

                return RedirectToAction("Guncelle");
            }

        }

    }
}