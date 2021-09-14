using Arayuz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KullaniciKismi.Models
{
    public class KullaniciSepet
    {
        public string Kullanici { get; set; }

        public List<SepetDetay> _SepetListesi = new List<SepetDetay>();

        public List<SepetDetay> SepetDetay
        {
            get { return _SepetListesi; }
        }

        public void SepetEkle(SepetDetay eklenenKitap)
        {
            var sepetim = _SepetListesi.Where(x => x.Kitap.Id == eklenenKitap.Kitap.Id).FirstOrDefault();

            if (sepetim == null || sepetim.Kitap.Id != eklenenKitap.Kitap.Id)    
            {
                _SepetListesi.Add(new SepetDetay()
                {
                    Kitap = eklenenKitap.Kitap,
                    Miktar = eklenenKitap.Miktar,
                    Toplam = eklenenKitap.Miktar * (eklenenKitap.Kitap.fiyat.HasValue ? eklenenKitap.Kitap.fiyat.Value : 0)
                });
            }
            else
            {
                
                sepetim.Miktar += eklenenKitap.Miktar;
                sepetim.Toplam += eklenenKitap.Miktar * (eklenenKitap.Kitap.fiyat.HasValue ? eklenenKitap.Kitap.fiyat.Value : 0);
            }
        }

        public void Sil(SepetDetay silinecekkitap)
        {                      
            _SepetListesi.RemoveAll(x => x.Kitap.Id == silinecekkitap.Kitap.Id);
        }

        public void Guncelle(SepetDetay guncellenecekkitap, int guncelmiktar)
        {

            var kitap = _SepetListesi.Where(x => x.Kitap.Id == guncellenecekkitap.Kitap.Id).FirstOrDefault();

            kitap.Miktar = guncelmiktar;
        }
        public double ToplamTutar()
        {
            return (double)_SepetListesi.Sum(x => x.Miktar * x.Kitap.fiyat);
        }
        public double Kdv()
        {
            return (double)_SepetListesi.Sum(x => x.Miktar * x.Kitap.fiyat) * 0.18;
        }
        public double Aratoplam()
        {
            return (double)_SepetListesi.Sum(x => x.Miktar * x.Kitap.fiyat) - Kdv();
        }
        public void Temizle()
        {
            _SepetListesi.Clear();
        }

        public int Sepetsayisi()
        {
            return _SepetListesi.Count();
        }
    }

    public class SepetDetay
    {
        public int KitapID { get; set; }
        public Arayuz.model.Kitaplar Kitap { get; set; }
        public Arayuz.model.YayinEvleri YayinEvi { get; set; }
        public int Miktar { get; set; }
        public decimal Toplam { get; set; }
    }
}