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
            _db.ExecuteCommand("DELETE FROM BusDynamic");
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
                _db.SubmitChanges();
            }
        }

        public List<BusDynamicDeserialize> GetBusDynamicInfo(IEnumerable<BusDynamicDeserialize> busDynamicCol)
        {
            List<ViewModels.BusDynamicDeserialize> busDynamicModelList = new List<BusDynamicDeserialize>();

            foreach (BusDynamicDeserialize item in busDynamicCol)
            {
                BusDynamicDeserialize busDynamicModel = new BusDynamicDeserialize();

                busDynamicModel.RouteID = item.RouteID;
                busDynamicModel.PlateNumb = item.PlateNumb;
                busDynamicModel.OperatorID = item.OperatorID;
                busDynamicModel.RouteUID = item.RouteUID;
                busDynamicModel.RouteName = item.RouteName;
                busDynamicModel.SubRouteUID = item.SubRouteUID;
                busDynamicModel.SubRouteID = item.SubRouteID;
                busDynamicModel.SubRouteName = item.SubRouteName;
                busDynamicModel.Direction = item.Direction;
                busDynamicModel.BusPosition = item.BusPosition;
                busDynamicModel.Speed = item.Speed;
                busDynamicModel.Azimuth = item.Azimuth;
                busDynamicModel.DutyStatus = item.DutyStatus;
                busDynamicModel.BusStatus = item.BusStatus;
                busDynamicModel.MessageType = item.MessageType;
                busDynamicModel.GPSTime = Convert.ToDateTime(item.GPSTime.ToString("yyyy-MM-dd HH:mm:ss"));
                busDynamicModel.SrcUpdateTime = Convert.ToDateTime(item.SrcUpdateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                busDynamicModel.UpdateTime = Convert.ToDateTime(item.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                busDynamicModelList.Add(busDynamicModel);
            }

            return busDynamicModelList;
        }
    }

    
}