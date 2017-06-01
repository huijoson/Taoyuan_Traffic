using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.Ubike
{
    public class UBikeDeserialize
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int _id { get; set; }
        /// <summary>
        /// 場站區域
        /// </summary>
        public string sarea { get; set; }
        /// <summary>
        /// 場站區域(英文)
        /// </summary>
        public string sareaen { get; set; }
        /// <summary>
        /// 場站名稱(中文)
        /// </summary>
        public string sna { get; set; }
        /// <summary>
        /// 場站區域(中文)
        /// </summary>
        public string aren { get; set; }
        /// <summary>
        /// 站點代號
        /// </summary>
        public string sno { get; set; }
        /// <summary>
        /// 場站總停車格
        /// </summary>
        public string tot { get; set; }
        /// <summary>
        /// 場站名稱(英文)
        /// </summary>
        public string snaen { get; set; }
        /// <summary>
        /// 空站數量(可還車位數)
        /// </summary>
        public string bemp { get; set; }
        /// <summary>
        /// 地址(中文)
        /// </summary>
        public string ar { get; set; }
        /// <summary>
        /// 全站禁用狀態(場站暫停營運)
        /// </summary>
        public string act { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        public string lng { get; set; }
        /// <summary>
        /// 場站目前車輛數量
        /// </summary>
        public string sbi { get; set; }
        /// <summary>
        /// 時間
        /// </summary>
        public string mday { get; set; }
    }
}