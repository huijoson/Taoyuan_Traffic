using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.Tidal
{
    public class TidalCusDeserialize
    {
        /// <summary>
        /// 地區
        /// </summary>
        public string locationName { get; set; }
        /// <summary>
        /// 農曆日期
        /// </summary>
        public string chineseDate { get; set; }
        /// <summary>
        /// 潮差
        /// </summary>
        public string tidalDiff { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public string dataTime { get; set; }
        /// <summary>
        /// 潮汐
        /// </summary>
        public string tidalStatus { get; set; }
        /// <summary>
        /// 潮高(TWWD)
        /// </summary>
        public string tidalTWVD { get; set; }
        /// <summary>
        /// 潮高(當地)
        /// </summary>
        public string tidalLocal { get; set; }
        /// <summary>
        /// 潮高(相對海圖)
        /// </summary>
        public string tidalRelationSea { get; set; }
    }
}