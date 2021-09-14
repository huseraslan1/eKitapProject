using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
    
    public class StokController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult Takip()
        {
            try
            {
                var liste = db.Kitaplars.ToList();

                return View(liste);
            }
            catch (Exception)
            {

                return RedirectToAction("Takip");
            }
            
        }

        public ActionResult Guncelle(int? id)
        {
            try
            {
                var guncellenecekStok = db.Kitaplars.Where(x => x.Id == id).FirstOrDefault();
                return View(guncellenecekStok);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]

        public ActionResult Guncelle(Kitaplar data)
        {
            try
            {
                Kitaplar guncellenecekAdet = db.Kitaplars.Where(x => x.Id == data.Id).FirstOrDefault();

                guncellenecekAdet.Adet = data.Adet;
                int sonuc = db.SaveChanges();

                if (sonuc==1)
                {
                    TempData["sonuc"] = 1;
                }

                return RedirectToAction("Takip");
            }
            catch (Exception)
            {

                return RedirectToAction("Takip");
            }
        }

    }
}