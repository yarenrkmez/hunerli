using MSharp.Framework;

using projemynei.Models;
using System;

using System.Linq;


using System.Web.Mvc;

namespace projemynei.Controllers
{
    public class HunerlilerController : Controller
    {
        // GET: Hunerliler

        private HunerlisEntities1 db = new HunerlisEntities1();


     
        public ActionResult Index()
        {
           
            var saticilar = db.Saticilars;
    
                return View(saticilar.ToList());
        }
     
   
    }
}