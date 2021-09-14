using Arayuz.arayuz;
using Arayuz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arayuz.repository
{
    public class KategoriRepository : Repository<Kategoriler>
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public void ekle(Kategoriler data)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(Kategoriler data)
        {
            throw new NotImplementedException();
        }

        public Kategoriler IdBilgisiGetir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Kategoriler> listeGetir()
        {
            return db.Kategoriler.ToList();
        }
        public List<Kategoriler> listeGetir2()
        {
            return db.Kategoriler.OrderByDescending(x => x.Id).ToList();
        }
    }
}
