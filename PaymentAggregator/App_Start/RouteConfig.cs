using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PaymentAggregator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CaseDetails",
                url: "cases/{alias}",
                defaults: new { controller = "Cases", action = "Details" }
            );

            routes.MapRoute(
                name: "CasesList",
                url: "cases",
                defaults: new { controller = "Cases", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cases", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}