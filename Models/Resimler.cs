//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projemynei.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resimler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resimler()
        {
            this.Kullanicilars = new HashSet<Kullanicilar>();
            this.Urunlers = new HashSet<Urunler>();
        }
    
        public int ResimID { get; set; }
        public Nullable<int> UrunID { get; set; }
        public string ResimYoluKullanici { get; set; }
        public string ResimYolu1Satici { get; set; }
        public string ResimYolu2Satici { get; set; }
        public string ResimYolu3Satici { get; set; }
        public Nullable<int> SaticiID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanicilar> Kullanicilars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}