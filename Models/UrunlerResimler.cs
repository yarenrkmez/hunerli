using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projemynei.Models
{
    public class UrunlerResimler
    {
        public IEnumerable<Urunler> urunlers { get; set; }

        public IEnumerable<Resimler> resimlers { get; set; }
    }
}