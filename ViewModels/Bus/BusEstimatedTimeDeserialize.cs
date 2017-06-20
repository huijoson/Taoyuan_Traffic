using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    public class BusEstimatedTimeDeserialize
    {
        /// <summary>
        /// 車牌號碼 [値為値為-1時，表示目前該站位無車輛行駛]
        /// </summary>
        public string PlateNumb { get; set; }
        /// <summary>
        /// 站牌唯一識別代碼，規則為 {業管機關代碼} + {StopID}，其中 {業管機關代碼} 
        /// </summary>
        public string StopUID { get; set; }
        /// <summary>
        /// 地區既用中之站牌代碼(為原資料內碼)
        /// </summary>
        public string StopID { get; set; }
        /// <summary>
        /// 站牌名
        /// </summary>
        public Stopname StopName { get; set; }
        /// <summary>
        /// 路線唯一識別代碼，規則為 {業管機關代碼} + {RouteID}，其中 {業管機關代碼} 
        /// </summary>
        public string RouteUID { get; set; }
        /// <summary>
        /// 地區既用中之路線代碼(為原資料內碼)
        /// </summary>
        public string RouteID { get; set; }
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
        /// 到站時間預估(秒) [當StopStatus値為1~4或PlateNumb値為-1時，EstimateTime値為空値; 反之，EstimateTime有値]
        /// </summary>
        public int EstimateTime { get; set; }
        /// <summary>
        /// 資料型態種類 = ['0: 未知', '1: 定期', '2: 非定期']
        /// </summary>
        public int MessageType { get; set; }
        /// <summary>
        /// 下一班公車到達時間
        /// </summary>
        public DateTime? NextBusTime { get; set; }
        /// <summary>
        /// 來源端平台資料更新時間
        /// </summary>
        public DateTime? SrcUpdateTime { get; set; }
        /// <summary>
        /// 本平台資料更新時間
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}