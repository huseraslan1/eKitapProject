using Arayuz.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KullaniciKismi.Controllers
{
    public class GirisController : Controller
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public ActionResult UyeKayit()
        {
            return View();
        }

        [HttpPost]

        public ActionResult UyeKayit(Musteri data)
        {
            try
            {
                var musteri = db.Musteri.Add(data);
                db.SaveChanges();

                return RedirectToAction("UyeKayit");
            }
            catch (Exception)
            {

                return RedirectToAction("UyeKayit");
            }
            
        }

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Giris(Musteri data,string UyeID)
        {
            Musteri giris = db.Musteri.Where(x => x.Eposta == data.Eposta && x.Sifre == data.Sifre).FirstOrDefault();

            if (giris==null)
            {
                TempData["sonuc"] = 0;
                return RedirectToAction("Index","Home");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(giris.Adi, true);

                HttpCookie cerez = new HttpCookie("kullaniciAdi", giris.Adi);
                cerez.Expires.AddDays(2);
                Response.Cookies.Add(cerez);

                Session.Add("uyeid",giris.Id);
                Session.Add("kullanıcı", giris.Adi);
                ViewBag.id = Session["uyeid"];
                TempData["sonuc"] = 1;
                return RedirectToAction("Index","Kullanici",new { UyeID = giris.Id });
            }
        }

        public ActionResult Cikis()
        {
            Response.Cookies["kullaniciAdi"].Expires = DateTime.Now.AddDays(-1);
            Session.Remove("UyeID");
            Session.Remove("kullanıcı");
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]

        public ActionResult SifreHatirlat(Musteri data)
        {
            Musteri sifrereset = db.Musteri.Where(x => x.Eposta == data.Eposta).FirstOrDefault();

            if (sifrereset!=null)
            {
                MailMessage _nm = new MailMessage();

                _nm.SubjectEncoding = Encoding.Default;
                _nm.Subject = "Şifre Hatırlatma";
                _nm.BodyEncoding = Encoding.Default;
                _nm.IsBodyHtml = true;
                _nm.Body =
                    "<br>Merhaba" + sifrereset.Adi +
                    "<br> Kullanıcı Adınız : " + sifrereset.Eposta +
                    "<br> Şifre :" + sifrereset.Sifre;

                _nm.From = new MailAddress(ConfigurationManager.AppSettings["emailAccount"]);
                _nm.To.Add(sifrereset.Eposta);

                SmtpClient _smtpClient = new SmtpClient();

                _smtpClient.Host = ConfigurationManager.AppSettings["emailhost"];
                _smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
                _smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
                _smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSLLEnable"]);

                _smtpClient.Send(_nm);


                TempData["sonuc"] = 1;
                return RedirectToAction("Home", "Index");
            }
            else
            {
                TempData["sonuc"] = 0;
            }
            return View();
        }
    }
}