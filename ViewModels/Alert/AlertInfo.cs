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
        public string name { get; set; }
        public string text { get; set; }
        public string term { get; set; }
    }
}