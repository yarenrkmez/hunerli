//using projemynei.Security;
using projemynei.App_Class;
using projemynei.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projemynei.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin

        private HunerlisEntities1 db = new HunerlisEntities1();
        public ActionResult Index()
        {
            HomePageViewModel k = new HomePageViewModel();
            k.saticilars = db.Saticilars.ToList();
            k.urunlers = db.Urunlers.ToList(); ;
            //var u = db.Urunlers;

            //return View(u.ToList());
            return View(k);

        }
        public ActionResult Urunlerim()
        {
            var kAdi = User.Identity.Name;
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Hunerlis;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select SaticiID from Saticilar where KullaniciAdi=" + "'" + kAdi + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int id;
            while (reader.Read())
            {
                id = reader.GetInt32(0) ;   
                ViewData["SaticiID"] = id;

            }

         
            reader.Close();
            conn.Close();
            Saticilar u = db.Saticilars.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name);
        

       
            ViewData["SaticiAdi"] = u.KullaniciAdi;

            ResimUrun k = new ResimUrun();

            k.resimlers = db.Resimlers.ToList();
            k.urunlers = db.Urunlers.ToList(); 
                return View(k);
         
            //var u = db.Urunlers;

            //return View(u.ToList());
            
       



        }  
   
  
      
        [HttpPost]
   
             
        public ActionResult UrunEkle(Saticilar s,Urunler k, Resimler r, HttpPostedFileBase Resim)
        {
     
              
            if (Resim != null)
            {

                string ResimAdi = System.IO.Path.GetFileName(Resim.FileName);
                string adres = Server.MapPath("/Image/" + ResimAdi);
                Resim.SaveAs(adres);
                r.ResimYolu1Satici = ResimAdi;

            }
            db.Resimlers.Add(r);
            var kAdi = User.Identity.Name;
         

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Hunerlis;Integrated Security=True");



            
            SqlCommand cmd = new SqlCommand("select SaticiID from Saticilar where KullaniciAdi=" + "'"+kAdi+"'", conn);
      

            conn.Open();
            //SqlDataAdapter adap = new SqlDataAdapter("SELECT top 1 UrunID FROM Urunler ORDER BY UrunID DESC", conn);
            //k.UrunID=adap.SelectCommand.ExecuteNonQuery.TempData  ;
          

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                k.SaticiID = reader.GetInt32(0) ;
                r.SaticiID= reader.GetInt32(0);

            }
            //k.SaticiID = Convert.ToInt32(reader.Read());           
            reader.Close();

            SqlCommand cmd2 = new SqlCommand("SELECT top 1 UrunID FROM Urunler ORDER BY UrunID DESC", conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                r.UrunID = reader2.GetInt32(0)+1;
            }
                //r.UrunID = reader2.Read().getInt
         
            reader2.Close();
            conn.Close();
     
            db.Urunlers.Add(k);
            //int y;

         
           
            //r.UrunID = ;
       
            db.SaveChanges();

            return RedirectToAction("Index","Admin");
        }
        public ActionResult BilgilerimiGuncelle()
        {
            return View();
        }

    }
    //}

}

     