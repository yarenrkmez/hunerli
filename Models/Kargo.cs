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
    
    public partial class Kargo
    {
        public int KargoID { get; set; }
        public string Aciklama { get; set; }
        public Nullable<int> SaticiID { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public Nullable<System.Guid> KargoTakipNo { get; set; }
    }
}
