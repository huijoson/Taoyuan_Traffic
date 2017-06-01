using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels;
using Taoyuan_Traffic.ViewModels.Parking;

namespace Taoyuan_Traffic.Models.Repository
{
    public class ParkingRepository : IParking
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
        public ParkingRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public ParkingRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~ParkingRepository()
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
        public void AddOutParking(IEnumerable<ParkingDeserialize> addParkingResource)
        {
            _db.ExecuteCommand("DELETE FROM Parking");
            foreach (ParkingDeserialize item in addParkingResource)
            {
                var newParking = new Parking
                {
                    parkName = item.parkName,
                    areaId = item.areaId,
                    wgsX = item.wgsX,
                    totalSpace = item.totalSpace,
                    introduction = item.introduction,
                    wgsY = item.wgsY,
                    parkId = item.parkId,
                    address = item.address,
                    payGuide = item.payGuide,
                    _id = item._id,
                    surplusSpace = item.surplusSpace,
                    areaName = item.areaName

                };
                _db.Parking.InsertOnSubmit(newParking);
                _db.SubmitChanges();
            }
        }

        public List<ParkingDeserialize> GetOutParkingInfo()
        {
            List<ParkingDeserialize> parkingInfoList = (from o in _db.Parking

                                                        select new ParkingDeserialize()
                                                         {
                                                            parkName = o.parkName,
                                                            areaId = o.areaId,
                                                            wgsX = o.wgsX.HasValue ? (float)o.wgsX.Value : 0,
                                                            totalSpace = o.totalSpace.HasValue ? (int)o.totalSpace : 0,
                                                            introduction = o.introduction,
                                                            wgsY = o.wgsY.HasValue ? (float)o.wgsY.Value : 0,
                                                            parkId = o.parkId,
                                                            address = o.address,
                                                            payGuide = o.payGuide,
                                                            _id = o._id.HasValue ? o._id.Value : 0,
                                                            surplusSpace = o.surplusSpace,
                                                            areaName = o.areaName
                                                         }).ToList();

            return parkingInfoList;
        }
    }
}