using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.Parking
{

    public class ParkingDeserialize
    {
        /// <summary>
        /// 停車場名稱
        /// </summary>
        public string parkName { get; set; }
        /// <summary>
        /// 地區編碼
        /// </summary>
        public string areaId { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        public float wgsY { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        public float wgsX { get; set; }
        /// <summary>
        /// 總車位數
        /// </summary>
        public int totalSpace { get; set; }
        /// <summary>
        /// 停車場介紹
        /// </summary>
        public string introduction { get; set; }
        /// <summary>
        /// 停車場編號
        /// </summary>
        public string parkId { get; set; }
        /// <summary>
        /// 停車場地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 停車場說明
        /// </summary>
        public string payGuide { get; set; }
        /// <summary>
        /// 停車場代號
        /// </summary>
        public int _id { get; set; }
        /// <summary>
        /// 剩餘車位數
        /// </summary>
        public string surplusSpace { get; set; }
        /// <summary>
        /// 地區名稱
        /// </summary>
        public string areaName { get; set; }
    }


}