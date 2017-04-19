using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.Models.Interface
{
    public interface IBusDynamic:IDisposable
    {
        /// <summary>
        /// 傳回使用的資料庫實體
        /// </summary>
        DataClassesDataContext Entity { get; }

        /// <summary>
        /// 新增公車資訊
        /// </summary>
        /// <param name="q"></param>
        void AddBusInfo(IEnumerable<BusDynamicDeserialize> AddBusDynamicSource);
    }
}