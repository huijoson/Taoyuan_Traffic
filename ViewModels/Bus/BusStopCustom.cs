using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    public class BusStopCustom
    {
        public Routename RouteName { get; set; }
        public int Direction { get; set; }
        public Stop[] Stops { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}