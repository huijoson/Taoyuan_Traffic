using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    public class BusEstimatedTimeDeserialize
    {
        public string PlateNumb { get; set; }
        public string StopUID { get; set; }
        public string StopID { get; set; }
        public Stopname StopName { get; set; }
        public string RouteUID { get; set; }
        public string RouteID { get; set; }
        public Routename RouteName { get; set; }
        public string SubRouteUID { get; set; }
        public string SubRouteID { get; set; }
        public Subroutename SubRouteName { get; set; }
        public int Direction { get; set; }
        public int MessageType { get; set; }
        public DateTime NextBusTime { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}