using projemynei.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace projemynei.Controllers
{

    public class IndexController : Controller

    {
        HunerlisEntities1 db = new HunerlisEntities1();
        // GET: Index
        public ActionResult Index()
        {

            SaticilarKullanicilar k = new SaticilarKullanicilar();
            k.saticilars = db.Saticilars.ToList();
            k.kullanicilars = db.Kullanicilars.ToList() ;
            return View(k);

        }
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
 
        public ActionResult Ekle(Kullanicilar k,Resimler r,HttpPostedFileBase Resim)
        {

            if (Resim != null)
            {

                string ResimAdi = System.IO.Path.GetFileName(Resim.FileName);
                string adres = Server.MapPath("/Image/" + ResimAdi);
                Resim.SaveAs(adres);
                r.ResimYoluKullanici = ResimAdi;
                //r.Kullanicilars.Add. = k.KullaniciID.ToString();
                //k.Resimler.ResimID = r.ResimID;

            }

            db.Resimlers.Add(r);


            db.Kullanicilars.Add(k);

            db.SaveChanges();

            return RedirectToAction("Index");
            //return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }
   


        [HttpPost]

        public ActionResult GirisYap(string KullaniciAdi, string Sifre)
        {
            Kullanicilar k = db.Kullanicilars.ToList().Where(x => x.KullaniciAdi.Equals(KullaniciAdi) && x.Sifre.Equals(Sifre)).FirstOrDefault();



            if (k != null)
            {
                FormsAuthentication.SetAuthCookie(k.KullaniciAdi, true);
     
                //FormsAuthentication.SetAuthCookie(k.KullaniciID.ToString(), true);
                ViewData["masaj"] = "Kullanici var.";

                return RedirectToAction("Index", "Index");
            }


            ViewData["masaj"] = "Kullanici yok.";

            return RedirectToAction("Index", "GirisYap");

        }
    
        [HttpPost]

        public ActionResult HunerliGirisYap(string KullaniciAdi, string Sifre)
        {
            Saticilar k = db.Saticilars.ToList().Where(x => x.KullaniciAdi.Equals(KullaniciAdi) && x.Sifre.Equals(Sifre)).FirstOrDefault();



            if (k != null)
            {
                FormsAuthentication.SetAuthCookie(k.KullaniciAdi, true);
                ViewData["masaj"] = "Kullanici var.";

                return RedirectToAction( "Index");
            }


            ViewData["masaj"] = "Kullanici yok.";
            
            return RedirectToAction("Index", "GirisYap");
            
        }



        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public ActionResult HunerliEkle(Saticilar s)
        {


            s.UserType = 2;
            db.Saticilars.Add(s);

            db.SaveChanges();


            return RedirectToAction("Index", "Index");
            //return View();
        }

     

        //[HttpPost]
        //public void Ara(int id)
        //{
        //    Kullanicilar u = db.Kullanicilars.FirstOrDefault(x => x.Resim == id);
        //    Context.Link.Products.Remove(u);
        //    Context.Link.SaveChanges();
        //}

    }
}