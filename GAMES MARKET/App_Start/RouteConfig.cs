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
                name: "Buy",
                url: "Buy",
                defaults: new { controller = "Buys", action = "Buy", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "About", action = "About", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Contact", action = "Contact", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Games", action = "Game", id = UrlParameter.Optional }
            );
        }
    }
}
