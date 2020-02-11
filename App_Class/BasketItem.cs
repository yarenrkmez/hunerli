using projemynei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projemynei.App_Class
{
    public class BasketItem
    {
        public Urunler urunler {get; set;}  
        public int Adet { get; set; }
        public decimal  Tutar
        {
            get
            {
                return Convert.ToInt32(urunler.Fiyati) * Adet;
            }
}

        
    }
}