using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proje.Models
{
    public class Durum
    {

        private Models.KitapProjesiEntities db;

        public Durum()
        {

            db = new Models.KitapProjesiEntities();

        }

        public durummodel durumModel()
        {
            durummodel model = new durummodel();

            model.siparissayisi = db.Siparis1.Count();
            model.siparisbekleyen = db.Siparis1.Where(x => x.SiparisDurumuID == 1).Count();
            model.musterisayisi = db.Musteris.Count();
            model.kitapsayisi = db.Kitaplars.Count();

            return model;

        }

        public class durummodel
        {

            public int kitapsayisi { get; set; }
            public int musterisayisi { get; set; }
            public int siparissayisi { get; set; }
            public int siparisbekleyen { get; set; }

        }
    }
}