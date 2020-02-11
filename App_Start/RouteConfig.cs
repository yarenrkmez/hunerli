using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace projemynei
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name: "Anasayfa",
            //    url: "",
            //    defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }
            //);


            //routes.MapRoute(
            //    name: "Kullanicilar",
            //    url: "Index/Liste/{siralama}/{sayfa}",
            //    defaults: new { controller =  "Kullanicilar", action = "KullaniciListesi", id = UrlParameter.Optional }
            //);



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
    

