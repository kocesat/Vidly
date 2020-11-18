using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //enable attribute routing
            routes.MapMvcAttributeRoutes();

            // most specific to general
            // Convention based custom route
            // There is a new way- Attribute routes
            //routes.MapRoute(
            //    "MoviesByReleasedDate",
            //    "movies/released/{year}/{month}",
            //    // set controller, action and defaults if any
            //    new { controller = "Movies", action = "ByReleaseDate"},
            //    // set constraints if any by regex.
            //    new { year = @"\d{4}", month = @"\d{2}" });
            //    //new { year = "2015|2016", month = @"\d{2}"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
