using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projemynei.Models
{
    public class SaticilarKullanicilar
    {
        public IEnumerable<Kullanicilar> kullanicilars { get; set; }

        public IEnumerable<Saticilar> saticilars { get; set; }
    }
}