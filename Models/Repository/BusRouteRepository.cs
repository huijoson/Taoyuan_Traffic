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
        public void clearBusRouteTable()
        {
            _db.ExecuteCommand("TRUNCATE TABLE BusRoute");
        }
        
        /// <summary>
        /// 新增公車路線資訊
        /// </summary>
        public int AddBusRoute(IEnumerable<BusRouteDeserialize> AddBusRouteSource, int count, int cityType)
        {
            foreach (BusRouteDeserialize item in AddBusRouteSource)
            {
                var newBusRoute = new BusRoute { };
                if (item.SubRoutes.Count() > 1)
                {
                    newBusRoute = new BusRoute
                    {
                        ID = count,
                        CityType = cityType,
                        RouteUID = item.RouteUID,
                        RouteID = item.RouteID,
                        AuthorityID = item.AuthorityID,
                        ProviderID = item.ProviderID,
                        GoSubRouteUID = item.SubRoutes[0].SubRouteUID,
                        GoSubRouteID = item.SubRoutes[0].SubRouteID,
                        GoSubRouteName = item.SubRoutes[0].SubRouteName.Zh_tw,
                        GoHeadsign = item.SubRoutes[0].Headsign,
                        GoDirection = item.SubRoutes[0].Direction,
                        BackSubRouteUID = item.SubRoutes[1].SubRouteUID,
                        BackSubRouteID = item.SubRoutes[1].SubRouteID,
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
                        CityType = cityType,
                        RouteUID = item.RouteUID,
                        RouteID = item.RouteID,
                        AuthorityID = item.AuthorityID,
                        ProviderID = item.ProviderID,
                        GoSubRouteUID = item.SubRoutes[0].SubRouteUID,
                        GoSubRouteID = item.SubRoutes[0].SubRouteID,
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
            return count;
        }
        /// <summary>
        /// 取得公車到站資訊
        /// </summary>
        /// <param name="AddBusEstimateSource"></param>
        public void AddBusEstimate(IEnumerable<BusEstimatedTimeDeserialize> AddBusEstimateSource)
        {
            var count = 1;
            _db.ExecuteCommand("TRUNCATE TABLE BusEstimate");
            foreach (BusEstimatedTimeDeserialize item in AddBusEstimateSource)
            {
                var newBusEstimate = new BusEstimate { };
                newBusEstimate = new BusEstimate
                {
                    ID = count,
                    PlateNumb = item.PlateNumb,
                    StopUID = item.StopUID,
                    StopID = item.StopID,
                    Stopname = item.StopName.Zh_tw,
                    RouteUID = item.RouteUID,
                    RouteID = item.RouteID,
                    Routename = item.RouteName.Zh_tw,
                    SubRouteUID = item.SubRouteUID,
                    SubRouteID = item.SubRouteID,
                    Subroutename = item.SubRouteName.Zh_tw,
                    Direction = item.Direction,
                    MessageType = item.MessageType,
                    NextBusTime = item.NextBusTime,
                    SrcUpdateTime = item.SrcUpdateTime,
                    UpdateTime = item.UpdateTime
                };
                count++;
                _db.BusEstimate.InsertOnSubmit(newBusEstimate);
            }
            _db.SubmitChanges();
        }

        /// <summary>
        /// 取得所有路線
        /// </summary>
        public List<ViewModels.GetRoute> GetRoute(int cityType=1, string keyWord="")
        {
            List<ViewModels.GetRoute> routeList = (from o in _db.BusRoute
                                                   where o.DepartureStopNameZh.Contains(keyWord) |
                                                        o.DestinationStopNameZh.Contains(keyWord) |
                                                        o.GoHeadsign.Contains(keyWord) |
                                                        o.RouteName.Contains(keyWord) &&
                                                        o.CityType.Equals(cityType)
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

        public List<ViewModels.BusEstimatedTime> GetBusEstimatedTime(IEnumerable<BusEstimatedTimeDeserialize> busEstimatedSource, int flag)
        {
            List<ViewModels.BusEstimatedTime> busEstimatedModelList = new List<BusEstimatedTime>();

            if (flag == 0)
            {
                foreach (ViewModels.BusEstimatedTimeDeserialize item in busEstimatedSource)
                {
                    BusEstimatedTime Obj = new BusEstimatedTime();
                    Obj.PlateNumb = item.PlateNumb;
                    Obj.StopUID = item.StopUID;
                    Obj.StopID = item.StopID;
                    Obj.StopName = item.StopName.Zh_tw;
                    Obj.RouteUID = item.RouteUID;
                    Obj.RouteID = item.RouteID;
                    Obj.RouteName = item.RouteName.Zh_tw;
                    Obj.RouteUID = item.RouteUID;
                    Obj.SubRouteID = item.SubRouteID;
                    Obj.SubRouteName = item.SubRouteName.Zh_tw;
                    Obj.Direction = item.Direction;
                    Obj.EstimateTime = item.EstimateTime;
                    Obj.MessageType = item.MessageType;
                    Obj.NextBusTime = item.NextBusTime;
                    Obj.SrcUpdateTime = item.SrcUpdateTime;
                    Obj.UpdateTime = item.UpdateTime;
                    busEstimatedModelList.Add(Obj);
                }
            }
            else
            {
                foreach (ViewModels.BusEstimatedTimeDeserialize item in busEstimatedSource)
                {
                    BusEstimatedTime Obj = new BusEstimatedTime();
                    Obj.PlateNumb = item.PlateNumb;
                    Obj.StopUID = item.StopUID;
                    Obj.StopID = item.StopID;
                    Obj.StopName = item.StopName.Zh_tw;
                    Obj.RouteUID = item.RouteUID;
                    Obj.RouteID = item.RouteID;
                    Obj.RouteName = item.RouteName.Zh_tw;
                    Obj.RouteUID = item.RouteUID;
                    Obj.Direction = item.Direction;
                    Obj.MessageType = item.MessageType;
                    Obj.EstimateTime = item.EstimateTime;
                    Obj.NextBusTime = item.NextBusTime;
                    Obj.SrcUpdateTime = item.SrcUpdateTime;
                    Obj.UpdateTime = item.UpdateTime;
                    busEstimatedModelList.Add(Obj);
                }
            }
            
            
            return busEstimatedModelList;
        }
    }
}