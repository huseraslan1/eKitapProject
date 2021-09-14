

using Proje.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Proje.Controllers
{
    
    public class KitaplarController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult Ekle()
        {
            ViewBag.kategori = db.Kategorilers.ToList();
            ViewBag.yayinEvi = db.YayinEvleris.ToList();
            return View();
        }

        [HttpPost]

        public ActionResult Ekle(Kitaplar data)
        {
            try
            {
                db.Kitaplars.Add(data);
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

        
        
        public ActionResult Kategori(int KategoriID)
        {
            var liste = db.Kategorilers.Where(x => x.Id == KategoriID).Select(x => new
            {
                x.Id,
                x.Tanim

            }).ToList();


            JavaScriptSerializer javaScript = new JavaScriptSerializer();

            string sonuc = javaScript.Serialize(liste);
            return Json(sonuc, JsonRequestBehavior.AllowGet);

        }


        
        public ActionResult YayinEviGetir(int YayinEviID)
        {
            var liste = db.YayinEvleris.Where(x => x.Id == YayinEviID).Select(x => new
            {

                x.Id,
                x.Tanim
            }).ToList();

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string sonuc = javaScriptSerializer.Serialize(liste);
            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ResimYukle()
        {
            if (Request.Files.Count > 0) 
            {
                try
                {
                    string resimler = "";
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string fisim;
                       
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fisim = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fisim = file.FileName;
                        }

                        fisim = Guid.NewGuid() + fisim; 
                        resimler += fisim + ";"; 

                        fisim = Path.Combine(Server.MapPath("/Content/resim/"), fisim);
                        file.SaveAs(fisim); 

                    }
                    
                    return Json(resimler);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("Dosya Seçilmedi");
            }


        }



        public ActionResult Liste(string ara)
        {
            try
            {
                var kitapListele = db.Kitaplars.ToList();
                if (!string.IsNullOrEmpty(ara))
                {
                    kitapListele = kitapListele.Where(x => x.Adi.ToString().ToLower().Contains(ara.ToLower())).ToList();
                }
                return View(kitapListele);
            }
            catch (Exception)
            {

                return RedirectToAction("Liste");
            }
        }

        public ActionResult Sil(int id)
        {
            try
            {
                var silinecekKitap = db.Kitaplars.Find(id);
                db.Kitaplars.Remove(silinecekKitap);
                int sonuc = db.SaveChanges();

                if (sonuc==1)
                {
                    TempData["sonuc"] = 1;
                }
            }
            catch (Exception)
            {

                return View("Liste");
            }
            return RedirectToAction("Liste");
        }

        public ActionResult Guncelle(int id)
        {
            var kategori = db.Kategorilers.ToList().Select(x => new SelectListItem
            {
                Selected = false,
                Text=x.Tanim,
                Value=x.Id.ToString()
            }).ToList();

            ViewBag.kategori = kategori;

            var yayinEvi = db.YayinEvleris.ToList().Select(x => new SelectListItem
            {
                Selected = false,
                Text=x.Tanim,
                Value=x.Id.ToString()
            }).ToList();

            ViewBag.yayinEvi = yayinEvi;

            var kitap = db.Kitaplars.Where(x => x.Id == id).FirstOrDefault();
            return View(kitap);
        }

        [HttpPost]

        public ActionResult Guncelle(Kitaplar data, HttpPostedFileBase file)
        {

            var guncellenecekKitap = db.Kitaplars.Where(x => x.Id == data.Id).FirstOrDefault();

            if (file != null)
            {
                if (file.ContentLength > 0)
                {

                    string uzanti = Path.GetExtension(Request.Files[0].FileName);

                    string resimadi = Guid.NewGuid() + uzanti;
                    string kok = Path.Combine(Server.MapPath("/Content/resim/"), resimadi);

                    using (var stream = new FileStream(kok, FileMode.Create))
                    {
                        file.InputStream.CopyTo(stream);

                    }

                    file.SaveAs(kok);

                    guncellenecekKitap.Resim = resimadi;

                }
            }
            else
            {
            guncellenecekKitap.Adi = data.Adi;
            guncellenecekKitap.Adet = data.Adet;
            guncellenecekKitap.Aciklama = data.Aciklama;
            guncellenecekKitap.fiyat = data.fiyat;
            guncellenecekKitap.KategoriID = data.KategoriID;
            guncellenecekKitap.StokKodu = data.StokKodu;
            guncellenecekKitap.Yazar = data.Yazar;
            guncellenecekKitap.YayinEviID = data.YayinEviID;
            }

            db.SaveChanges();
            return RedirectToAction("Liste");
        }
    }
}