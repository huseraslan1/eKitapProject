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
    
    public partial class TeslimatBilgileri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeslimatBilgileri()
        {
            this.Kitaplars = new HashSet<Kitaplar>();
        }
    
        public int Id { get; set; }
        public string Tanim { get; set; }
        public string Icerik { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
