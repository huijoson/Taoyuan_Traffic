using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.TRA
{

    public class ParkingDeserialize
    {
        public string parkName { get; set; }
        public string areaId { get; set; }
        public float wgsX { get; set; }
        public int totalSpace { get; set; }
        public string introduction { get; set; }
        public float wgsY { get; set; }
        public string parkId { get; set; }
        public string address { get; set; }
        public string payGuide { get; set; }
        public int _id { get; set; }
        public string surplusSpace { get; set; }
        public string areaName { get; set; }
    }
}