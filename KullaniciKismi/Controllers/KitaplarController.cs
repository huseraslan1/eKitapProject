using Arayuz.model;
using Arayuz.repository;
using Arayuz.Repository;
using KullaniciKismi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KullaniciKismi.Controllers
{
    public class KitaplarController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();

        KitapRepository kitapRepository = new KitapRepository();
        TeslimatRepository teslimatRepository = new TeslimatRepository();
        YorumRepository yorumRepository = new YorumRepository();
        YayinEviRepository yayinEviRepository = new YayinEviRepository();
        KategoriRepository kategoriRepository = new KategoriRepository();
        SepetRepository siparis = new SepetRepository();
        public ActionResult Detay(int? id)
        {
            if (id == null || id < 1)
            {
                return RedirectToAction("Index", "Home");
            }

            var secilenKitap = kitapRepository.IdBilgisiGetir(id.Value);
            ViewBag.teslimat = teslimatRepository.listeGetir();

            Session.Add("kitapId", id);

            return View(secilenKitap);
        }

        [HttpPost]

        public ActionResult Detay(SepetID data)
        {
            var secilenKitap = kitapRepository.IdBilgisiGetir(data.Id);

            sepetim().SepetEkle(

                new SepetDetay
                {
                    Kitap = secilenKitap,

                    Miktar = data.Miktar.Value

                });
            return RedirectToAction("Sepetsayfasi");
        }

        public KullaniciSepet sepetim()
        {
            var list = (KullaniciSepet)Session["Sepet"];

            if (list == null)
            {
                list = new KullaniciSepet();
                Session["Sepet"] = list;
            }
            return list;
        }

        public ActionResult Sepetsayfasi()
        {
            return View();
        }

        public ActionResult Sepettencikar(int KitapID)
        {
            SepetDetay silinecekkitap = sepetim().SepetDetay.Where(x => x.Kitap.Id == KitapID).FirstOrDefault();

            sepetim().Sil(silinecekkitap);

            return RedirectToAction("Sepetsayfasi");
        }

        public PartialViewResult sepettekikitaplar()
        {
            return PartialView(sepetim());
        }

        public ActionResult Tamamla(int id)
        {
            var musteri = siparis.IdBilgisineGoreGetir(id);

            if (musteri == null)
            {
                return View(sepetim());
            }
            ViewBag.odeme = siparis.listegetir();
            ViewBag.kargo = siparis.KargoListele();
            TempData["adres"] = musteri.TeslimatAdresi;
            TempData["Adi"] = musteri.Adi;

            return View(sepetim());
        }

        [HttpPost]

        public ActionResult Tamamla(Siparis data, SiparisDetay data1)
        {
            var secilenKitap = kitapRepository.IdBilgisiGetir(data1.KitapID.Value);
            for (int i = 0; i < sepetim().Sepetsayisi(); i++)
            {
                SiparisDetay siparisDetay = new SiparisDetay()
                {
                    KitapID = data1.KitapID,
                    Fiyat = data1.Fiyat,
                    Miktar = data1.Miktar,
                    OdemeYontemiID = data1.OdemeYontemiID,
                    //YayinEviID=data1.Kitaplar.YayinEvleri.Id
                    KargoID=data1.KargoID
                };
                db.SiparisDetay.Add(siparisDetay);
                db.SaveChanges();

                Siparis siparis = new Siparis()
                {
                    SatisTarihi = DateTime.Now,
                    MusteriID = data.MusteriID,
                    SiparisDurumuID = data.SiparisDurumuID,
                    OdemeYontemiID = data1.OdemeYontemiID,
                    SepetDetayID = siparisDetay.Id
                };
                db.Siparis.Add(siparis);
                db.SaveChanges();
            }
            SepetID sepet = new SepetID()
            {
                Toplam = (decimal)sepetim().ToplamTutar(),
                Miktar=data1.Miktar,
                KitapID=data1.KitapID,
                YayinEviID=data1.YayinEviID
                
            };
            db.SepetID.Add(sepet);
            db.SaveChanges();    
            return RedirectToAction("SiparisOnay");

        }

        public ActionResult SiparisOnay()
        {
            return View(sepetim());
        }


        [HttpPost]

        public ActionResult YorumEkle(Yorumlar data)
        {
            //Session.Add("kitabaDon", data.Kitaplar);
            try
            {
                db.Yorumlar.Add(data);
                db.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("Detay");
            }
            return RedirectToAction("Detay");
        }

        public PartialViewResult Kategori()
        {
            KategoriRepository kategorilerRepository = new KategoriRepository();

            var liste = kategorilerRepository.listeGetir();
            return PartialView(liste);
        }

        public ActionResult KategoriListesi(int id)
        {
            var liste = db.Kitaplar.Where(x => x.Kategoriler.Id == id).Take(9).ToList();
            return View(liste);
        }

        public PartialViewResult SolMenuKategori()
        {
            KategoriRepository kategorilerRepository = new KategoriRepository();

            var liste = kategorilerRepository.listeGetir();
            return PartialView(liste);
        }
    }
}