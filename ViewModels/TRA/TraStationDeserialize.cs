using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.TRA
{
    public class TraStationDeserialize
    {
        public string StationID { get; set; }
        public Stationname StationName { get; set; }
        public Stationposition StationPosition { get; set; }
        public string StationAddress { get; set; }
        public string StationPhone { get; set; }
        public string OperatorID { get; set; }
        public string StationClass { get; set; }
        public string ReservationCode { get; set; }
    }
}