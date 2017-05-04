using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.ViewModels.TRA
{
    public class TraLineDeserialize
    {
        /// <summary>
        /// 路線編號
        /// </summary>
        public string LineNo { get; set; }
        /// <summary>
        /// 路線代碼
        /// </summary>
        public string LineID { get; set; }
        /// <summary>
        /// 路線中文名稱
        /// </summary>
        public string LineNameZh { get; set; }
        /// <summary>
        /// 路線英文名稱
        /// </summary>
        public string LineNameEn { get; set; }
        /// <summary>
        /// 路線區間中文名稱
        /// </summary>
        public string LineSectionNameZh { get; set; }
        /// <summary>
        /// 路線區間英文名稱
        /// </summary>
        public string LineSectionNameEn { get; set; }
        /// <summary>
        /// 是否位於支線
        /// </summary>
        public bool IsBranch { get; set; }
    }
}