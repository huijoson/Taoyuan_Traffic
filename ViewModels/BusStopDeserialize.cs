using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    
    public class BusStopDeserialize
    {
        public string RouteUID { get; set; }
        public string RouteID { get; set; }
        public Routename RouteName { get; set; }
        public bool KeyPattern { get; set; }
        public string SubRouteUID { get; set; }
        public string SubRouteID { get; set; }
        public Subroutename SubRouteName { get; set; }
        public int Direction { get; set; }
        public Stop[] Stops { get; set; }
        public string UpdateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
    
}