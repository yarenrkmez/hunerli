using projemynei.App_Class;
using projemynei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace projemynei.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        HunerlisEntities1 db = new HunerlisEntities1();
        public ActionResult Index()
        {
            UrunlerResimler k = new UrunlerResimler();
            k.urunlers = db.Urunlers.ToList();
            k.resimlers = db.Resimlers.ToList();

            return View(k);

        }

        public void SepeteEkle(int id)
        {
            BasketItem ba = new BasketItem();
            Urunler u = db.Urunlers.FirstOrDefault(x => x.UrunID == id);
            ba.urunler = u;
            ba.Adet = 1;
            Basket b = new Basket();
            b.SepeteEkle(ba);
            //MiniSepetWidget();

        }
        public void SepetUrunSil(int id)
        {
            if (HttpContext.Session["AktifSepet"] != null)
            {
                Basket b = (Basket)HttpContext.Session["AktifSepet"];
                if (b.Urunler.FirstOrDefault(x => x.urunler.UrunID == id).Adet > 1)
                {
                    b.Urunler.FirstOrDefault(x => x.urunler.UrunID == id).Adet--;
                }

                else
                {
                    BasketItem bi = b.Urunler.FirstOrDefault(x => x.urunler.UrunID == id);
                    b.Urunler.Remove(bi);
                }
            }
        }
        public PartialViewResult MiniSepetWidget()
        {
            if (HttpContext.Session["AktifSepet"] != null)
            {
                return PartialView((Basket)HttpContext.Session["AktifSepet"]);
            }
            else
                return PartialView();
        }
        public ActionResult UrunDetay(int id)
        {

            UrunlerResimler k = new UrunlerResimler();
            k.resimlers = db.Resimlers.ToList();
            k.urunlers = db.Urunlers.ToList();

 
            Urunler u  = db.Urunlers.FirstOrDefault(x => x.UrunID == id);
            ViewData["urunid"] = u.UrunID;
            return View(k);
        }

        public ActionResult Sepetim()
        {
            if (User.Identity.Name!="")
            {
               
                BilgilerKullanicilar k = new BilgilerKullanicilar();
                k.kullanicilars = db.Kullanicilars.ToList();
                k.bilgilers = db.Bilgilers.ToList();
                Kullanicilar u = db.Kullanicilars.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name);
  
                ViewData["id"] = u.KullaniciID;
                ViewData["ad"] = u.KullaniciAdi;
                ViewData["satisid"] = db.Database.SqlQuery<int>("select top 1 ID from Satis order by ID desc");
                //select top 1 ID from Satis order by ID desc
                //var results = db.Satis.Select(i => i.ID).Take(1);
                //var results = db.Satis.OrderByDescending(g => g.ID).Distinct().Take(1);
                //       var results = db.Satis.GroupBy(g => g.ID).Where(w => w.Count() > 1)
                //.Select(s =>
                //    new {
                //        s.FirstOrDefault().Kullanicilar.Satis,
                //        adet = s.Count()
                //    }).Distinct().Take(1).OrderByDesceding(o => o.adet).ToList();
                //foreach (var item in results)
                //{

                //}

                //ViewData["satisid"] = results;

                //db.Database.SqlQuery<int>("ProcedureAdı").ToList();

                return View(k);
            }
            return RedirectToAction("Index","Index/GirisYap");


        }
        [HttpPost]
        public ActionResult Islemlerim(Bilgiler b)
        {
            Kullanicilar u = db.Kullanicilars.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name);
            
            db.Bilgilers.Add(b);
            b.KullaniciID = u.KullaniciID;
            db.SaveChanges();
            return RedirectToAction("Sepetim","Urunler");

        }
        
        [HttpPost]
        public ActionResult Ode(Sepet s,Sati sati)
        {
            Kullanicilar u = db.Kullanicilars.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name);

            ViewData["dene"] = "deneme";
            sati.MusteriID = u.KullaniciID;
            sati.SatisTarihi = DateTime.Now;
Random rastgele = new Random();
            sati.KargoTakipNo =  rastgele.Next();
    
            db.Satis.Add(sati);
            s.SatisID = 2;
           
            db.Sepets.Add(s);
            db.SaveChanges();
        
            return RedirectToAction("Index", "Index/Index");
        }

    }
}