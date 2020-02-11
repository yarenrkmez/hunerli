using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projemynei.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Saticilar> saticilars { get; set; }
        public IEnumerable<Urunler> urunlers { get; set; }
    }
}