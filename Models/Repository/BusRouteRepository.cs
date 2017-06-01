using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.ViewModels;
using Taoyuan_Traffic.Models.Interface;

namespace Taoyuan_Traffic.Models.Repository
{
    public class BusRouteRepository : IBusRoute
    {
        /// <summary>
        /// (私有) 資料庫實體資料集合
        /// </summary>
        private DataClassesDataContext _db;

        /// <summary>
        /// 目前時間
        /// </summary>
        private DateTime _now = DateTime.Now;

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        public BusRouteRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public BusRouteRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~BusRouteRepository()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 傳回使用的資料庫實體
        /// </summary>
        public DataClassesDataContext Entity
        {
            get
            {
                return _db;
            }
        }

        #region 實作IDisposable

        private bool _disposed = false;

        /// <summary>
        /// 資源釋放
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    if (_db != null) _db.Dispose();
                }
            }
            _disposed = true;
        }

        #endregion 實作IDisposable

        /// <summary>
        /// 新增熱門關鍵字
        /// </summary>
        public void AddBusRoute(IEnumerable<BusRouteDeserialize> AddBusRouteSource)
        {
            var count = 1;
            _db.ExecuteCommand("TRUNCATE TABLE BusRoute");
            foreach (BusRouteDeserialize item in AddBusRouteSource)
            {
                var newBusRoute = new BusRoute { };
                if (item.SubRoutes.Count() > 1)
                {
                    newBusRoute = new BusRoute
                    {
                        ID = count,
                        RouteUID = item.RouteUID,
                        RouteID = item.RouteID,
                        OperatorIDs = item.OperatorIDs[0],
                        AuthorityID = item.AuthorityID,
                        ProviderID = item.ProviderID,
                        GoSubRouteUID = item.SubRoutes[0].SubRouteUID,
                        GoSubRouteID = item.SubRoutes[0].SubRouteID,
                        GoOperatorIDs = item.SubRoutes[0].OperatorIDs[0],
                        GoSubRouteName = item.SubRoutes[0].SubRouteName.Zh_tw,
                        GoHeadsign = item.SubRoutes[0].Headsign,
                        GoDirection = item.SubRoutes[0].Direction,
                        BackSubRouteUID = item.SubRoutes[1].SubRouteUID,
                        BackSubRouteID = item.SubRoutes[1].SubRouteID,
                        BackOperatorIDs = item.SubRoutes[1].OperatorIDs[0],
                        BackSubRouteName = item.SubRoutes[1].SubRouteName.Zh_tw,
                        BackHeadsign = item.SubRoutes[1].Headsign,
                        BackDirection = item.SubRoutes[1].Direction,
                        BusRouteType = item.BusRouteType,
                        RouteName = item.RouteName.Zh_tw,
                        DepartureStopNameZh = item.DepartureStopNameZh,
                        DestinationStopNameZh = item.DestinationStopNameZh,
                        UpdateDate = item.UpdateDate,
                        UpdateTime = item.UpdateTime
                    };
                }
                else
                {
                    newBusRoute = new BusRoute
                    {
                        ID = count,
                        RouteUID = item.RouteUID,
                        RouteID = item.RouteID,
                        OperatorIDs = item.OperatorIDs[0],
                        AuthorityID = item.AuthorityID,
                        ProviderID = item.ProviderID,
                        GoSubRouteUID = item.SubRoutes[0].SubRouteUID,
                        GoSubRouteID = item.SubRoutes[0].SubRouteID,
                        GoOperatorIDs = item.SubRoutes[0].OperatorIDs[0],
                        GoSubRouteName = item.SubRoutes[0].SubRouteName.Zh_tw,
                        GoHeadsign = item.SubRoutes[0].Headsign,
                        GoDirection = item.SubRoutes[0].Direction,
                        BusRouteType = item.BusRouteType,
                        RouteName = item.RouteName.Zh_tw,
                        DepartureStopNameZh = item.DepartureStopNameZh,
                        DestinationStopNameZh = item.DestinationStopNameZh,
                        UpdateDate = item.UpdateDate,
                        UpdateTime = item.UpdateTime
                    };
                }
                count++;
                _db.BusRoute.InsertOnSubmit(newBusRoute);
            }
            _db.SubmitChanges();
        }

        /// <summary>
        /// 取得所有路線
        /// </summary>
        public List<ViewModels.GetRoute> GetAllRoute()
        {
            List<ViewModels.GetRoute> routeList = (from o in _db.BusRoute
                                                   select new ViewModels.GetRoute()
                                                   {
                                                       RouteUID = o.RouteUID,
                                                       RouteID = o.RouteID,
                                                       RouteName = o.RouteName,
                                                       Direction = o.BackDirection.HasValue ? o.BackDirection.Value : 0,
                                                       DepartureStopNameZh = o.DepartureStopNameZh,
                                                       DestinationStopNameZh = o.DestinationStopNameZh,
                                                       Headsign = o.BackHeadsign==null ? o.BackHeadsign : o.GoHeadsign,
                                                   }).ToList();

            return routeList;
        }

        public List<ViewModels.GetRoute> GetSearchRoute(string keyWord)
        {
            List<ViewModels.GetRoute> routeList = (from o in _db.BusRoute
                                                   where o.DepartureStopNameZh.Contains(keyWord) |
                                                         o.DestinationStopNameZh.Contains(keyWord) |
                                                         o.GoHeadsign.Contains(keyWord) |
                                                         o.RouteName.Contains(keyWord)
                                                   select new ViewModels.GetRoute()
                                                   {
                                                       RouteUID = o.RouteUID,
                                                       RouteID = o.RouteID,
                                                       RouteName = o.RouteName,
                                                       Direction = o.BackDirection.HasValue ? o.BackDirection.Value : 0,
                                                       DepartureStopNameZh = o.DepartureStopNameZh,
                                                       DestinationStopNameZh = o.DestinationStopNameZh,
                                                       Headsign = o.BackHeadsign == null ? o.BackHeadsign : o.GoHeadsign,
                                                   }).ToList();

            return routeList;
        }

        public List<ViewModels.BusEstimatedTimeDeserialize> GetBusEstimatedTime(IEnumerable<BusEstimatedTimeDeserialize> busEstimated)
        {
            List<ViewModels.BusEstimatedTimeDeserialize> busEstimatedModelList = new List<BusEstimatedTimeDeserialize>();
            
            foreach (BusEstimatedTimeDeserialize item in busEstimated)
            {
                BusEstimatedTimeDeserialize busEstimatedModel = new BusEstimatedTimeDeserialize();
                busEstimatedModel.PlateNumb = item.PlateNumb;
                busEstimatedModel.StopUID = item.StopUID;
                busEstimatedModel.StopID = item.StopID;
                busEstimatedModel.StopName = item.StopName;
                busEstimatedModel.RouteUID = item.RouteUID;
                busEstimatedModel.RouteID = item.RouteID;
                busEstimatedModel.RouteName = item.RouteName;
                busEstimatedModel.SubRouteUID = item.SubRouteUID;
                busEstimatedModel.SubRouteID = item.SubRouteID;
                busEstimatedModel.SubRouteName = item.SubRouteName;
                busEstimatedModel.Direction = item.Direction;
                busEstimatedModel.MessageType = item.MessageType;
                busEstimatedModel.NextBusTime = Convert.ToDateTime(item.NextBusTime.ToString("yyyy-MM-dd HH:mm:ss"));
                busEstimatedModel.SrcUpdateTime = Convert.ToDateTime(item.SrcUpdateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                busEstimatedModel.UpdateTime = Convert.ToDateTime(item.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                busEstimatedModelList.Add(busEstimatedModel);
            }

            return busEstimatedModelList;
        }
    }
}