using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    public class GetRoute
    {
        public string RouteUID { get; set;}
        public string RouteID { get; set;}
        public string RouteName { get; set;}
        public int GoDirection { get; set;}
        public int BackDirection { get; set;}
        public string DepartureStopNameZh { get; set;}
        public string DestinationStopNameZh { get; set;}
        public string GoHeadsign { get; set; }
        public string BackHeadsign { get; set; }
    }
}