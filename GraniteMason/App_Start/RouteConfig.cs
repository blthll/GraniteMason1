using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GraniteMason
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "About",
               url: "About",
               defaults: new { controller = "Hakkimda", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Cabinets",
               url: "Cabinets",
               defaults: new { controller = "Cabinet", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Gallery",
               url: "Gallery",
               defaults: new { controller = "Galeri", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Contact",
               url: "Contact",
               defaults: new { controller = "Iletisim", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
