using Arayuz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arayuz.repository
{
    public class SepetRepository
    {
        KitapProjesiEntities db = new KitapProjesiEntities();

        public bool ekle(SepetID data)
        {
            db.SepetID.Add(data);
            int sonuc = db.SaveChanges();

            if (sonuc == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Musteri IdBilgisineGoreGetir(int id)
        {
            return db.Musteri.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<OdemeYontemi> listegetir()
        {
            return db.OdemeYontemi.OrderByDescending(x => x.Id).ToList();
        }

        public List<KargoFirmasi> KargoListele()
        {
            return db.KargoFirmasi.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
