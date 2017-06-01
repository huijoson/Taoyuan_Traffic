using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    /// <summary>
    /// 取得所有公車路線
    /// </summary>
    public class GetRoute
    {
        /// <summary>
        /// 路線唯一識別代碼，規則為 {業管機關代碼} + {RouteID}
        /// </summary>
        public string RouteUID { get; set;}
        /// <summary>
        /// 地區既用中之路線代碼(為原資料內碼) 
        /// </summary>
        public string RouteID { get; set;}
        /// <summary>
        /// 路線名稱
        /// </summary>
        public string RouteName { get; set;}
        /// <summary>
        /// 去返程 = ['0: 去程', '1: 返程']
        /// </summary>
        public int Direction { get; set;}
        /// <summary>
        /// 起站中文名稱
        /// </summary>
        public string DepartureStopNameZh { get; set;}
        /// <summary>
        /// 終點站中文名稱
        /// </summary>
        public string DestinationStopNameZh { get; set;}
        /// <summary>
        /// 車頭描述
        /// </summary>
        public string Headsign { get; set; }
    }
}