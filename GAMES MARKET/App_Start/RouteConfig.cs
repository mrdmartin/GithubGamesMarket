using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GAMES_MARKET
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "About",
                url: "About",
                defaults: new { controller = "About", action = "About", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                "Contact",
                url: "Contact",
                defaults: new { controller = "Contact", action = "Contact", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Games", action = "Game", id = UrlParameter.Optional }
            );
        }
    }
}
