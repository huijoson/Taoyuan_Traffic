using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.FreeWay
{
    public class FreeWayDeserialize
    {
        /// <summary>
        /// 公司編號
        /// </summary>
        public int rID { get; set; }
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string addr { get; set; }
        /// <summary>
        /// 公司電話
        /// </summary>
        public string phoneNum { get; set; }
        /// <summary>
        /// 免付費電話
        /// </summary>
        public string freephoneNum { get; set; }
        /// <summary>
        /// 小型車輛救援(有:Y、無:N)
        /// </summary>
        public string smallCar { get; set; }
        /// <summary>
        /// 大型車輛救援(有:Y、無:N)
        /// </summary>
        public string largeCar { get; set; }
    }
}