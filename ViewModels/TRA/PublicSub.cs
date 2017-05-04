using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.TRA
{
    public class PublicSub
    {
    }

    public class Stationname
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

    public class Stationposition
    {
        public float PositionLat { get; set; }
        public float PositionLon { get; set; }
    }

    public class Trainclassificationname
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }


    public class Dailytraininfo
    {
        public string TrainNo { get; set; }
        public int Direction { get; set; }
        public string StartingStationID { get; set; }
        public Startingstationname StartingStationName { get; set; }
        public string EndingStationID { get; set; }
        public Endingstationname EndingStationName { get; set; }
        public string TrainClassificationID { get; set; }
        public int TripLine { get; set; }
        public bool WheelchairFlag { get; set; }
        public bool PackageServiceFlag { get; set; }
        public bool DiningFlag { get; set; }
        public bool BikeFlag { get; set; }
        public bool BreastFeedingFlag { get; set; }
        public bool DailyFlag { get; set; }
        public bool ServiceAddedFlag { get; set; }
        public Note Note { get; set; }
        public string UpdateDate { get; set; }
    }

    public class Note
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

    public class Originstoptime
    {
        public int StopSequence { get; set; }
        public string StationID { get; set; }
        public Stationname StationName { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
    }

    public class Destinationstoptime
    {
        public int StopSequence { get; set; }
        public string StationID { get; set; }
        public Stationname1 StationName { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
    }

    public class Stationname1
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }


    public class Startingstationname
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

    public class Endingstationname
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

    public class Traintypename
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }
}