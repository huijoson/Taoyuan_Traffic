using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    public class BusDynamic
    {
        /// <summary>
        /// 路線ID
        /// </summary>
        public string RouteID { get; set; }
        /// <summary>
        /// 車牌號碼
        /// </summary>
        public string PlateNumb { get; set; }
        /// <summary>
        /// 營運業者代碼
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 路線唯一識別代碼，規則為 {業管機關代碼} + {RouteID}，其中 {業管機關代碼}
        /// </summary>
        public string RouteUID { get; set; }
        /// <summary>
        /// 路線名稱
        /// </summary>
        public Routename RouteName { get; set; }
        /// <summary>
        /// 子路線唯一識別代碼，規則為 {業管機關代碼} + {SubRouteID}，其中 {業管機關代碼}
        /// </summary>
        public string SubRouteUID { get; set; }
        /// <summary>
        /// 地區既用中之子路線代碼(為原資料內碼) 
        /// </summary>
        public string SubRouteID { get; set; }
        /// <summary>
        /// 子路線名稱
        /// </summary>
        public Subroutename SubRouteName { get; set; }
        /// <summary>
        /// 去返程 = ['0: 去程', '1: 返程']
        /// </summary>
        public int Direction { get; set; }
        /// <summary>
        /// 車輛位置經度
        /// </summary>
        public double PositionLat { get; set; }
        public double PositionLon { get; set; }
        /// <summary>
        /// 行駛速度(kph) 
        /// </summary>
        public double Speed { get; set; }
        /// <summary>
        /// 方位角
        /// </summary>
        public double Azimuth { get; set; }
        /// <summary>
        /// 勤務狀態 = ['0: 正常', '1: 開始', '2: 結束']
        /// </summary>
        public int DutyStatus { get; set; }
        /// <summary>
        /// 行車狀況 = ['0: 正常', '1: 車禍', '2: 故障', '3: 塞車', '4: 緊急求援', '5: 加油', '90: 不明', '91: 去回不明', '98: 偏移路線', '99: 非營運狀態', '100: 客滿', '101: 包車出租', '255: 未知']
        /// </summary>
        public int BusStatus { get; set; }
        /// <summary>
        /// 資料型態種類 = ['0: 未知', '1: 定期', '2: 非定期']
        /// </summary>
        public int MessageType { get; set; }
        /// <summary>
        /// 車機時間
        /// </summary>
        public DateTime GPSTime { get; set; }
        /// <summary>
        /// 來源端平台接收時間
        /// </summary>
        public DateTime SrcUpdateTime { get; set; }
        /// <summary>
        /// 本平台資料更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}