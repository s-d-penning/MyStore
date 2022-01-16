using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyStore.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "PiesCreate", url: "Pies/Create", defaults: new { controller = "Pies", action = "Create" });

            routes.MapRoute(name: "PiesbyCategorybyPage", url: "Pies/{category}/Page{page}", defaults: new { controller = "Pies", action = "Index" });

            routes.MapRoute(name: "PiesbyPage", url: "Pies/Page{page}", defaults: new { controller = "Pies", action = "Index" });

            routes.MapRoute(name: "PiesByCategory", url: "Pies/{category}", defaults: new { controller = "Pies", action = "Index" });

            routes.MapRoute(name: "PiesIndex", url: "Pies", defaults: new { controller = "Pies", action = "Index" });

            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
