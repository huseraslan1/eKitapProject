//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arayuz.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class KargoFirmasi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KargoFirmasi()
        {
            this.SiparisDetay = new HashSet<SiparisDetay>();
        }
    
        public int Id { get; set; }
        public string Sirket { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string WebSitesi { get; set; }
        public string Eposta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetay> SiparisDetay { get; set; }
    }
}