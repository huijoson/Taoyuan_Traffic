using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Taoyuan_Traffic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BusApiV1",
                url: "api/v1/Bus/{controller}/{action}",
                namespaces: new string[] { "BusDynamicController", "BusRouteController", "BusStopController" }
            );

            routes.MapRoute(
                name: "TRAApiV1",
                url: "api/v1/TRA/{controller}/{action}",
                namespaces: new string[] { "TraLineController" }
            );

            routes.MapRoute(
                name: "WeatherApiV1",
                url: "api/v1/Weather/{controller}/{action}",
                namespaces: new string[] { "TaoyuanWeathertController" }
            );

            routes.MapRoute(
                name: "ParkingApiV1",
                url: "api/v1/Park/{controller}/{action}",
                namespaces: new string[] { "ParkingController" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
