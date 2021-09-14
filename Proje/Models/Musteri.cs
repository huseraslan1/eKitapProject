//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proje.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteri()
        {
            this.Yorumlars = new HashSet<Yorumlar>();
            this.Siparis = new HashSet<Siparis>();
        }
    
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        public Nullable<System.DateTime> DogumTarihi { get; set; }
        public string Sifre { get; set; }
        public Nullable<int> SepetID { get; set; }
        public Nullable<int> LoginID { get; set; }
        public Nullable<int> SiparisGecmisID { get; set; }
        public Nullable<int> YorumID { get; set; }
        public string TeslimatAdresi { get; set; }
    
        public virtual Giris Giris { get; set; }
        public virtual SepetID SepetID1 { get; set; }
        public virtual SiparisGecmisi SiparisGecmisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis { get; set; }
    }
}
