using Arayuz.arayuz;
using Arayuz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
namespace Arayuz.Repository
{
    public class KitapRepository : Repository<Kitaplar>
    {

        KitapProjesiEntities db = new KitapProjesiEntities();
        public void ekle(Kitaplar data)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(Kitaplar data)
        {
            throw new NotImplementedException();
        }

        public Kitaplar IdBilgisiGetir(int id)
        {
            return db.Kitaplar.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Kitaplar> listeGetir()
        {
            return db.Kitaplar.OrderByDescending(x => x.Id).Take(10).ToList();
        }

    }
}
