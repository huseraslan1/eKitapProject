using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
   
    public class SiparisController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult Liste()
        {
            var liste = db.Siparis1.ToList();
            return View(liste);
        }

        public ActionResult Sil(int id)
        {

            Siparis siparisler = (from x in db.Siparis1 where x.Id == id select x).FirstOrDefault();

            return View(siparisler);
        }


        [HttpPost, ActionName("Sil")]

        public ActionResult Silmeislemi(int id)
        {
            Siparis silineceksiparisler = (from x in db.Siparis1 where x.Id == id select x).FirstOrDefault();

            int? musteri = silineceksiparisler.MusteriID;
            int? SiparisDurumu = silineceksiparisler.SiparisDurumuID;
            int? OdemeYontemi = silineceksiparisler.OdemeYontemiID;
            int? SepetId = silineceksiparisler.SepetDetayID;

            db.Siparis1.Remove(silineceksiparisler);
            int sonuc = db.SaveChanges();
            if (sonuc == 1)
            {
                TempData["sonuc"] = 1;

            }

            return RedirectToAction("Liste");
        }

        public ActionResult SiparisDetay(int id)
        {
            var siparisDetay = db.Siparis1.Where(x => x.Id == id).FirstOrDefault();

            var siparisdurum = db.SiparisDurumus.ToList().Select(x => new
              SelectListItem
            {
                Selected = false,
                Text = x.Tanim,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.siparisdurum = siparisdurum;
            return View(siparisDetay);
        }

        [HttpPost]
        public ActionResult SiparisDetay(Siparis data)
        {

            try
            {
                var durum = db.Siparis1.Where(x => x.Id == data.Id).FirstOrDefault();

                durum.SiparisDurumuID = data.SiparisDurumuID;

                durum.KargoTakip = data.KargoTakip;

                db.SaveChanges();

                return RedirectToAction("Liste", data.Id);

            }
            catch (Exception)
            {

                return RedirectToAction("SiparisDetay", data.Id);

            }

        }
    }
}