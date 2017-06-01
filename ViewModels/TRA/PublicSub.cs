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
        /// <summary>
        /// 車次代碼
        /// </summary>
        public string TrainNo { get; set; }
        /// <summary>
        /// 順逆行 = ['0: 順行', '1: 逆行']
        /// </summary>
        public int Direction { get; set; }
        /// <summary>
        /// 列車起點車站代號
        /// </summary>
        public string StartingStationID { get; set; }
        /// <summary>
        /// 列車起點車站名稱
        /// </summary>
        public Startingstationname StartingStationName { get; set; }
        /// <summary>
        /// 列車終點車站代號
        /// </summary>
        public string EndingStationID { get; set; }
        /// <summary>
        /// 列車終點車站名稱
        /// </summary>
        public Endingstationname EndingStationName { get; set; }
        /// <summary>
        /// 列車車種代碼
        /// </summary>
        public string TrainClassificationID { get; set; }
        /// <summary>
        /// 山海線類型 = ['0: 不經山海線', '1: 山線', '2: 海線']
        /// </summary>
        public int TripLine { get; set; }
        /// <summary>
        /// 是否提供輪椅服務
        /// </summary>
        public bool WheelchairFlag { get; set; }
        /// <summary>
        /// 是否提供行李服務
        /// </summary>
        public bool PackageServiceFlag { get; set; }
        /// <summary>
        /// 是否提供餐車服務 
        /// </summary>
        public bool DiningFlag { get; set; }
        /// <summary>
        /// 是否可攜帶自行車
        /// </summary>
        public bool BikeFlag { get; set; }
        /// <summary>
        /// 是否設有哺乳室
        /// </summary>
        public bool BreastFeedingFlag { get; set; }
        /// <summary>
        /// 是否每日行駛
        /// </summary>
        public bool DailyFlag { get; set; }
        /// <summary>
        /// 是否為加班車
        /// </summary>
        public bool ServiceAddedFlag { get; set; }
        /// <summary>
        /// 附註說明
        /// </summary>
        public Note Note { get; set; }
        /// <summary>
        /// 資料更新日期
        /// </summary>
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