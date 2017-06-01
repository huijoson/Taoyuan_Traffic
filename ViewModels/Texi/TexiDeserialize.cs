using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.Text
{
    public class TexiDeserialize
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int tID { get; set; }
        /// <summary>
        /// 計程車公司
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        public string Lat { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        public string Lon { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string Addr { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 所在範圍
        /// </summary>
        public string Area { get; set; }
    }
}