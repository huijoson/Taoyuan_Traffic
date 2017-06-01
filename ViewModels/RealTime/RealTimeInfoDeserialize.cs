using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.RealTime
{

    public class RealTimeInfoDeserialize
    {
        /// <summary>
        /// 東南西北部
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 來源單位
        /// </summary>
        public string srcdetail { get; set; }
        /// <summary>
        /// 區域
        /// </summary>
        public string areaNm { get; set; }
        /// <summary>
        /// 訊息編號
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// 雙向或單向
        /// </summary>
        public string direction { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        public string y1 { get; set; }
        /// <summary>
        /// 發生時間
        /// </summary>
        public string happentime { get; set; }
        /// <summary>
        /// 路況狀況
        /// </summary>
        public string roadtype { get; set; }
        /// <summary>
        /// 哪一條路
        /// </summary>
        public string road { get; set; }
        /// <summary>
        /// 發布時間
        /// </summary>
        public string modDttm { get; set; }
        /// <summary>
        /// 路況敘述
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 發生日期
        /// </summary>
        public string happendate { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        public string x1 { get; set; }
    }
}
