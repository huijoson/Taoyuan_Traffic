using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels
{
    public class BusStopCustom
    {
        /// <summary>
        /// 路線名稱
        /// </summary>
        public Routename RouteName { get; set; }
        /// <summary>
        /// 去返程 = ['0: 去程', '1: 返程']
        /// </summary>
        public int Direction { get; set; }
        /// <summary>
        /// 所有經過站牌 
        /// </summary>
        public Stop[] Stops { get; set; }
        /// <summary>
        /// 資料更新日期
        /// </summary>
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 資料更新日期時間
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}