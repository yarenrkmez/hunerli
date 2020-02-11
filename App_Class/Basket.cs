using projemynei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projemynei.App_Class
{
    public class Basket
    {

        //public List<Urunler> urunlers = new List<Urunler>();
        public static Basket AktifSepet
        {
            get
            {
                HttpContext ctx = HttpContext.Current;
                if(ctx.Session["AktifSepet"]==null)
                {
                    ctx.Session["AktifSepet"] = new Basket();
                  
                }
                return (Basket)ctx.Session["AktifSepet"];
            }
        }
        public List<BasketItem> urunler = new List<BasketItem>();//--
        public List<BasketItem>Urunler
        {
            get
            {
                return urunler;
            }
            set { urunler = value; }
        }
        public void SepeteEkle(BasketItem ba)
        {
            if(HttpContext.Current.Session["AktifSepet"] != null)
            {
                Basket b = (Basket)HttpContext.Current.Session["AktifSepet"];
                if (b.Urunler.Any(x => x.urunler.UrunID == ba.urunler.UrunID))
                {
                    b.Urunler.FirstOrDefault(x => x.urunler.UrunID == ba.urunler.UrunID).Adet++;
                }

                else
                {
                    b.Urunler.Add(ba);
                }
          
            }
            else
            {
                Basket b = new Basket();
                b.Urunler.Add(ba);
                HttpContext.Current.Session["AktifSepet"] = b;
                }
        }
            public decimal ToplamTutar
        {
            get
            {
                return Urunler.Sum(x => x.Tutar);
            }
            
        }
    




    }
}
