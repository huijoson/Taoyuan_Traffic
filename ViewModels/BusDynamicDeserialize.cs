using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.Models
{

    public class BusDynamicDeserialize
    {
        public string PlateNumb { get; set; }
        public string OperatorID { get; set; }
        public string RouteUID { get; set; }
        public string RouteID { get; set; }
        public Routename RouteName { get; set; }
        public string SubRouteUID { get; set; }
        public string SubRouteID { get; set; }
        public Subroutename SubRouteName { get; set; }
        public int Direction { get; set; }
        public Busposition BusPosition { get; set; }
        public float Speed { get; set; }
        public float Azimuth { get; set; }
        public int DutyStatus { get; set; }
        public int BusStatus { get; set; }
        public int MessageType { get; set; }
        public DateTime GPSTime { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    public class Routename
    {
        public string Zh_tw { get; set; }
    }

    public class Subroutename
    {
        public string Zh_tw { get; set; }
    }

    public class Busposition
    {
        public float PositionLat { get; set; }
        public float PositionLon { get; set; }
    }
}