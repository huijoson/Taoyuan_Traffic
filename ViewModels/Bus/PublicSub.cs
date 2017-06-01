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
        /// <summary>
        /// 路線名稱
        /// </summary>
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
        /// <summary>
        /// 路線名稱
        /// </summary>
        public string Zh_tw { get; set; }
    }

    public class Busposition
    {
        /// <summary>
        /// 位置緯度(WGS84) 
        /// </summary>
        public float PositionLat { get; set; }
        /// <summary>
        /// 位置經度(WGS84)
        /// </summary>
        public float PositionLon { get; set; }
    }

    public class Stop
    {
        /// <summary>
        /// 站牌唯一識別代碼，規則為 {業管機關代碼} + {StopID}，其中 {業管機關代碼}
        /// </summary>
        public string StopUID { get; set; }
        /// <summary>
        /// 地區既用中之站牌代碼(為原資料內碼)
        /// </summary>
        public string StopID { get; set; }
        /// <summary>
        /// 站牌名稱
        /// </summary>
        public Stopname StopName { get; set; }
        /// <summary>
        /// 上下車站別 = ['0: 可上下車', '1: 可上車', '-1: 可下車']
        /// </summary>
        public int StopBoarding { get; set; }
        /// <summary>
        /// 路線經過站牌之順序
        /// </summary>
        public int StopSequence { get; set; }
        /// <summary>
        /// 站牌位置
        /// </summary>
        public Stopposition StopPosition { get; set; }
    }

    public class Stopname
    {
        /// <summary>
        /// 站牌名稱
        /// </summary>
        public string Zh_tw { get; set; }
    }

    public class Stopposition
    {
        /// <summary>
        /// 位置緯度(WGS84) 
        /// </summary>
        public float PositionLat { get; set; }
        /// <summary>
        /// 位置經度(WGS84)
        /// </summary>
        public float PositionLon { get; set; }
    }

}