using Arayuz.arayuz;
using Arayuz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arayuz.repository
{
    public class TeslimatRepository : Repository<TeslimatBilgileri>
    {

        KitapProjesiEntities db = new KitapProjesiEntities();
        public void ekle(TeslimatBilgileri data)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(TeslimatBilgileri data)
        {
            throw new NotImplementedException();
        }

        public TeslimatBilgileri IdBilgisiGetir(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeslimatBilgileri> listeGetir()
        {
            return db.TeslimatBilgileri.ToList();
        }
    }
}
