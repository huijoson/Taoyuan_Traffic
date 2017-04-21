using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    public class PublicSub
    {
    }

    public class Routename
    {
        public string Zh_tw { get; set; }
    }

    public class Subroute
    {
        public string SubRouteUID { get; set; }
        public string SubRouteID { get; set; }
        public string[] OperatorIDs { get; set; }
        public Subroutename SubRouteName { get; set; }
        public string Headsign { get; set; }
        public int Direction { get; set; }
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

    public class Stop
    {
        public string StopUID { get; set; }
        public string StopID { get; set; }
        public Stopname StopName { get; set; }
        public int StopBoarding { get; set; }
        public int StopSequence { get; set; }
        public Stopposition StopPosition { get; set; }
    }

    public class Stopname
    {
        public string Zh_tw { get; set; }
    }

    public class Stopposition
    {
        public float PositionLat { get; set; }
        public float PositionLon { get; set; }
    }

}