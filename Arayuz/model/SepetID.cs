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
    
    public partial class SepetID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SepetID()
        {
            this.Musteri = new HashSet<Musteri>();
        }
    
        public int Id { get; set; }
        public Nullable<int> KitapID { get; set; }
        public Nullable<int> YayinEviID { get; set; }
        public Nullable<int> Miktar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musteri> Musteri { get; set; }
        public decimal Toplam { get; set; }
        public decimal Toplamm { get; set; }
    }
}