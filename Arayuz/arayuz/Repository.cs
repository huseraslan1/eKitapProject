using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arayuz.arayuz
{
    public interface Repository<T> where T : class
    {
        List<T> listeGetir();

        void ekle(T data);

        bool guncelle(T data);

        T IdBilgisiGetir(int id);
    }
}
