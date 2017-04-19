using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.ViewModels;
using Taoyuan_Traffic.Models.Interface;

namespace Taoyuan_Traffic.Models.Repository
{
    public class BusRouteRepository:IBusRoute
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
            _db.ExecuteCommand("DELETE FROM BusRoute");
            foreach (BusRouteDeserialize item in AddBusRouteSource)
            {
                var newBusRoute = new BusRoute { };
                if (item.SubRoutes.Count() > 1)
                {

                    //newBusRoute = new BusRoute();
                    //newBusRoute.RouteUID = item.RouteUID;
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
                _db.SubmitChanges();
            }
        }
    }
}