using Arayuz.arayuz;
using Arayuz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arayuz.repository
{
    public class YorumRepository : Repository<Yorumlar>
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public void ekle(Yorumlar data)
        {
            db.Yorumlar.Add(data);
            db.SaveChanges();
        }

        public bool guncelle(Yorumlar data)
        {
            throw new NotImplementedException();
        }

        public Yorumlar IdBilgisiGetir(int id)
        {
            return db.Yorumlar.Where(x => x.KitapID == id).FirstOrDefault();
        }

        public List<Yorumlar> listeGetir()
        {
            return db.Yorumlar.OrderByDescending(x => x.Id).Take(10).ToList();
        }
    }
}
