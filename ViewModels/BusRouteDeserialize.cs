using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    public class BusRouteDeserialize
    {
        public string RouteUID { get; set; }
        public string RouteID { get; set; }
        public string[] OperatorIDs { get; set; }
        public string AuthorityID { get; set; }
        public string ProviderID { get; set; }
        public Subroute[] SubRoutes { get; set; }
        public int BusRouteType { get; set; }
        public Routename RouteName { get; set; }
        public string DepartureStopNameZh { get; set; }
        public string DestinationStopNameZh { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}