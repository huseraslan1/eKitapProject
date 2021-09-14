using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Proje.Controllers
{
   
    public class KategorilerController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Ekle(Kategoriler data)
        {
            try
            {
                var kategori = db.Kategorilers.Add(data);
                kategori.UstKategoriID = 0;
                int sonuc = db.SaveChanges();

                if (sonuc == 1)
                {
                    TempData["sonuc"] = "1";
                }
                else
                {
                    TempData["sonuc"] = "0";
                }
            }
            catch (Exception)
            {

                return View("Ekle");
            }
            return View("Ekle");
        }


        public ActionResult Liste()
        {
            try
            {
                var liste = db.Kategorilers.ToList();
                return View(liste);
            }
            catch (Exception)
            {

                return View("Ekle");
            }
        }

        public PartialViewResult KategoriListe()
        {
            var liste = db.Kategorilers.ToList();
            return PartialView(liste);
        }

        public ActionResult KategoriSil(int id)
        {
            try
            {
                var silinecek = db.Kategorilers.Find(id);
                db.Kategorilers.Remove(silinecek);
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

                return RedirectToAction("Liste");
            }

            
        }

        public ActionResult Guncelle(int id)
        {
            try
            {
                if (id==null)
                {
                    return RedirectToAction("Liste");
                }

                var guncellenecekKategori = db.Kategorilers.Where(x => x.Id == id).FirstOrDefault();

                if (guncellenecekKategori==null)
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
        public ActionResult Guncelle(Kategoriler data) 
        {
            try
            {
                Kategoriler guncellenecek = db.Kategorilers.FirstOrDefault(x => x.Id == data.Id);

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
         public ActionResult AltKategori()
        {
            var kategori = db.Kategorilers.ToList().Select(x => new SelectListItem
            {
                Selected = false,
                Text = x.Tanim,
                Value = x.Id.ToString()

            }).ToList();


            ViewBag.kategori = kategori;
            return View();
         }

        [HttpPost]
        public ActionResult AltKategori(Kategoriler data)
        {
            try
            {
                var eklenecekAltKategori = db.Kategorilers.Add(data);
                eklenecekAltKategori.UstKategoriID = data.Id;

                db.SaveChanges();

                return View("Ekle");
            }
            catch (Exception)
            {

                return View("Ekle");
            }
        }
    }
}