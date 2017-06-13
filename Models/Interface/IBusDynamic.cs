using System;
using System.Collections.Generic;
using Taoyuan_Traffic.ViewModels;

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
        void AddBusInfo(IEnumerable<BusDynamicDeserialize> AddBusDynamicSource);
        List<ViewModels.BusDynamic> GetBusDynamicInfo(string routeName);
    }
}