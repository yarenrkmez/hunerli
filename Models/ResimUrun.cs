using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projemynei.Models
{
    public class ResimUrun
    {
        public IEnumerable<Resimler> resimlers { get; set; }
        public IEnumerable<Urunler> urunlers { get; set; }

        //public IEnumerable<Saticilar> saticilars { get; set; }

    }
}