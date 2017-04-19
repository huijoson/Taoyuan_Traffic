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

}