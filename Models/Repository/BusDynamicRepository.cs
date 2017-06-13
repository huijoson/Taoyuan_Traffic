using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.ViewModels;
using Taoyuan_Traffic.Models.Interface;

namespace Taoyuan_Traffic.Models.Repository
{
    public class BusDynamicRepository:IBusDynamic
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
        public BusDynamicRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public BusDynamicRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~BusDynamicRepository()
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
        public void AddBusInfo(IEnumerable<BusDynamicDeserialize> AddBusDynamicSource)
        {
            var count = 1;
            _db.ExecuteCommand("TRUNCATE TABLE BusDynamic");
            foreach (BusDynamicDeserialize item in AddBusDynamicSource)
            {
                var newBusInfo = new BusDynamic
                {
                    ID = count,
                    PlateNumb               = item.PlateNumb,
                    OperatorID              = item.OperatorID,
                    RouteUID                = item.RouteUID,
                    RouteID                 = item.RouteID,
                    RouteName               = item.RouteName.Zh_tw,
                    SubRouteUID             = item.SubRouteUID,
                    SubRouteID              = item.SubRouteID,
                    SubRouteName            = item.SubRouteName.Zh_tw,
                    Direction               = item.Direction,
                    Speed                   = item.Speed,
                    Azimuth                 = item.Azimuth,
                    DutyStatus              = item.DutyStatus,
                    BusStatus               = item.BusStatus,
                    MessageType             = item.MessageType,
                    GPSTime                 = item.GPSTime,
                    SrcUpdateTime           = item.SrcUpdateTime,
                    UpdateTime              = item.UpdateTime,
                    PositionLat             = item.BusPosition.PositionLat,
                    PositionLon             = item.BusPosition.PositionLon
                    
                };
                count++;
                _db.BusDynamic.InsertOnSubmit(newBusInfo);
            }
            _db.SubmitChanges();
        }

        public List<ViewModels.BusDynamic> GetBusDynamicInfo(string routeName)
        {
            List<ViewModels.BusDynamic> busDynamicModelList = new List<ViewModels.BusDynamic>();
            var query = (from o in _db.BusDynamic select o).AsEnumerable();
            foreach(var item in query)
            {
                ViewModels.BusDynamic busD = new ViewModels.BusDynamic();
                Routename rN = new Routename();
                Subroutename srN = new Subroutename();
                busD.RouteID = item.RouteID;
                busD.PlateNumb = item.PlateNumb;
                busD.OperatorID = item.OperatorID;
                busD.RouteUID = item.RouteUID;
                rN.Zh_tw = item.RouteName;
                busD.RouteName = rN;
                busD.SubRouteUID = item.SubRouteUID;
                busD.SubRouteID = item.SubRouteID;
                srN.Zh_tw = item.SubRouteName;
                busD.SubRouteName = srN;
                busD.Direction = item.Direction.HasValue?item.Direction.Value:0;
                busD.PositionLat = item.PositionLat.HasValue ? item.PositionLat.Value : 0;
                busD.PositionLon = item.PositionLon.HasValue ? item.PositionLon.Value : 0;
                busD.Speed = item.Speed.HasValue ? item.Speed.Value : 0;
                busD.Azimuth = item.Azimuth.HasValue ? item.Azimuth.Value : 0;
                busD.DutyStatus = item.DutyStatus.HasValue ? item.DutyStatus.Value : 0;
                busD.BusStatus = item.BusStatus.HasValue ? item.BusStatus.Value : 0;
                busD.MessageType = item.MessageType.HasValue ? item.MessageType.Value : 0;
                busD.GPSTime = item.GPSTime.HasValue ? item.GPSTime.Value : DateTime.Now;
                busD.SrcUpdateTime = item.SrcUpdateTime.HasValue ? item.SrcUpdateTime.Value : DateTime.Now;
                busD.UpdateTime = item.UpdateTime.HasValue ? item.UpdateTime.Value : DateTime.Now;
                busDynamicModelList.Add(busD);
            }

            return busDynamicModelList;
        }
    }

    
}