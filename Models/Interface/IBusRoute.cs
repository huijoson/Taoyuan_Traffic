using System;
using System.Collections.Generic;
using Taoyuan_Traffic.ViewModels;

namespace Taoyuan_Traffic.Models.Interface
{
    public interface IBusRoute:IDisposable
    {
        /// <summary>
        /// 傳回使用的資料庫實體
        /// </summary>
        DataClassesDataContext Entity { get; }

        /// <summary>
        /// 新增公車資訊
        /// </summary>
        /// <param name="q"></param>
        void AddBusRoute(IEnumerable<BusRouteDeserialize> AddBusRouteSource);

        List<ViewModels.GetRoute> GetAllRoute();

        List<ViewModels.GetRoute> GetSearchRoute(string keyWord);

        List<ViewModels.BusEstimatedTimeDeserialize> GetBusEstimatedTime(IEnumerable<BusEstimatedTimeDeserialize> busEstimated);
    }
}
