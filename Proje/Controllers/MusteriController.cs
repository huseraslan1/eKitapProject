using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
    
    public class MusteriController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();

        public ActionResult Liste()
        {
            var musteri = db.Musteris.ToList();


            return View(musteri);
        }

        public ActionResult Guncelle(int id)
        {


            var guncelenecekmusteri = db.Musteris.Where(x => x.Id == id).FirstOrDefault();

            return View(guncelenecekmusteri);
        }

        [HttpPost]

        public ActionResult Guncelle(Musteri data)
        {

            var guncelenecekmusteri = db.Musteris.Where(x => x.Id == data.Id).FirstOrDefault();

            guncelenecekmusteri.Adi = data.Adi;
            guncelenecekmusteri.DogumTarihi = data.DogumTarihi;
            guncelenecekmusteri.Eposta = data.Eposta;
            guncelenecekmusteri.Sifre = data.Sifre;
            guncelenecekmusteri.Soyadi = data.Soyadi;
            guncelenecekmusteri.TeslimatAdresi = data.TeslimatAdresi;

            db.SaveChanges();

            return RedirectToAction("Liste");
        }
    }
}