using Arayuz.arayuz;
using Arayuz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arayuz.repository
{
    public class YayinEviRepository : Repository<YayinEvleri>
    {
        KitapProjesiEntities db = new KitapProjesiEntities();
        public void ekle(YayinEvleri data)
        {
            throw new NotImplementedException();
        }

        public bool guncelle(YayinEvleri data)
        {
            throw new NotImplementedException();
        }

        public YayinEvleri IdBilgisiGetir(int id)
        {
            return db.YayinEvleri.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<YayinEvleri> listeGetir()
        {
            throw new NotImplementedException();
        }
    }
}
