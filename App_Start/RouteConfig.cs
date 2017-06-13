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
                namespaces: new string[] { "BusDynamicController", "BusRouteController", "BusStopController", "BusEstimateController" }
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
                namespaces: new string[] { "ParkingController", "ParkingOutController" }
            );

            routes.MapRoute(
                name: "AlertApiV1",
                url: "api/v1/Alert/{controller}/{action}",
                namespaces: new string[] { "AlertCustController" }
            );

            routes.MapRoute(
                name: "RealTimeApiV1",
                url: "api/v1/RealTime/{controller}/{action}",
                namespaces: new string[] { "RealTimeTrafficInfoController" }
            );

            routes.MapRoute(
                name: "UBikeApiV1",
                url: "api/v1/UBike/{controller}/{action}",
                namespaces: new string[] { "UBikeInfoController" }
            );

            routes.MapRoute(
                name: "RestApiV1",
                url: "api/v1/Rest/{controller}/{action}",
                namespaces: new string[] { "RestInfoController" }
            );

            routes.MapRoute(
                name: "FreeWayApiV1",
                url: "api/v1/FreeWay/{controller}/{action}",
                namespaces: new string[] { "FreeWayInfoController" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
