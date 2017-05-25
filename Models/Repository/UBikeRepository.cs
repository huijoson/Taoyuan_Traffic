using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Ubike;

namespace Taoyuan_Traffic.Models.Repository
{
    public class UBikeRepository : IUBike
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
        public UBikeRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public UBikeRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~UBikeRepository()
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
        public void AddUBikeInfo(IEnumerable<UBikeDeserialize> addUBikeResource)
        {
            _db.ExecuteCommand("DELETE FROM UBikeTable");
            foreach (UBikeDeserialize item in addUBikeResource)
            {
                var newUBikeInfo = new UBikeTable
                {
                    _id = item._id,
                    sarea = item.sarea,
                    sareaen = item.sareaen,
                    sna = item.sna,
                    aren = item.aren,
                    sno = item.sno,
                    tot = item.tot,
                    snaen = item.snaen,
                    bemp = item.bemp,
                    ar = item.ar,
                    act = item.act,
                    lat = item.lat,
                    lng = item.lng,
                    sbi = item.sbi,
                    mday = item.mday

                };
                _db.UBikeTable.InsertOnSubmit(newUBikeInfo);
                _db.SubmitChanges();
            }
        }

        public List<UBikeDeserialize> GetUbikeInfo()
        {
            List<UBikeDeserialize> UBikeInfoList = (from o in _db.UBikeTable
                                                    select new UBikeDeserialize
                                                    {
                                                        _id = o._id,
                                                        sarea = o.sarea,
                                                        sareaen = o.sareaen,
                                                        sna = o.sna,
                                                        snaen = o.snaen,
                                                        bemp = o.bemp,
                                                        ar = o.ar,
                                                        act = o.act,
                                                        lat = o.lat,
                                                        lng = o.lng,
                                                        sbi = o.sbi,
                                                        mday = o.mday,
                                                        aren = o.aren,
                                                        sno = o.sno,
                                                        tot = o.tot
                                                    }).ToList();
            return UBikeInfoList;
        }
    }
}

    