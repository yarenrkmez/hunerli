using projemynei.App_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projemynei.Models
{
    public class BilgilerKullanicilar
    {
        public IEnumerable<Bilgiler> bilgilers { get; set; }

        public IEnumerable<Kullanicilar> kullanicilars { get; set; }
        public IEnumerable<Basket> baskets { get; set; }
        public IEnumerable<Urunler> urunlers { get; set; }


    }
}