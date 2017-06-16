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
        void clearBusRouteTable();
        int AddBusRoute(IEnumerable<BusRouteDeserialize> AddBusRouteSource, int count, int cityType);

        void AddBusEstimate(IEnumerable<BusEstimatedTimeDeserialize> AddBusEstimateSource);

        List<ViewModels.GetRoute> GetRoute(int cityType = 1, string keyWord = "");

        List<ViewModels.GetRoute> GetSearchRoute(string keyWord);

        List<ViewModels.BusEstimatedTime> GetBusEstimatedTime(IEnumerable<BusEstimatedTimeDeserialize> busEstimatedSource, int flag);
    }
}
