using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.Alert
{
    public class AlertInfo
    {   
        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime updated { get; set; }
        /// <summary>
        /// 發布單位
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 災害敘述
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 災害類型
        /// </summary>
        public string term { get; set; }
    }
}