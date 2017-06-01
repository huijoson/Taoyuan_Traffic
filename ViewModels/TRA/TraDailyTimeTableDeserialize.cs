using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.TRA
{
    public class TraDailyTimeTableDeserialize
    {
        /// <summary>
        /// 行駛日期
        /// </summary>
        public string TrainDate { get; set; }
        /// <summary>
        /// 車次資料
        /// </summary>
        public Dailytraininfo DailyTrainInfo { get; set; }
        /// <summary>
        /// 起站停靠時間資料
        /// </summary>
        public Originstoptime OriginStopTime { get; set; }
        /// <summary>
        /// 迄站停靠時間資料
        /// </summary>
        public Destinationstoptime DestinationStopTime { get; set; }
        /// <summary>
        /// 資料更新日期
        /// </summary>
        public string UpdateDate { get; set; }
    }
}