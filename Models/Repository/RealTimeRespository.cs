using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.RealTime;

namespace Taoyuan_Traffic.Models.Repository
{
    public class RealTimeRespository : IRealTime
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
        public RealTimeRespository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public RealTimeRespository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~RealTimeRespository()
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

        public void addRealTimeInfo(IEnumerable<RealTimeInfoDeserialize> realTimeInfoSource)
        {
            _db.ExecuteCommand("DELETE FROM RealTimeTable");
            foreach (RealTimeInfoDeserialize item in realTimeInfoSource)
            {
                var newRealTime = new RealTimeTable
                {
                    region = item.region,
                    srcdetail = item.srcdetail,
                    areaNm = item.areaNm,
                    UID = item.UID,
                    direction = item.direction,
                    y1 = item.y1,
                    x1 = item.x1,
                    happendate = item.happendate,
                    roadtype = item.roadtype,
                    road = item.road,
                    modDttm = item.modDttm,
                    comment = item.comment,
                    happentime = item.happentime,
                };



                _db.RealTimeTable.InsertOnSubmit(newRealTime);
                _db.SubmitChanges();
            }
        }

        public List<RealTimeInfoDeserialize> getRealTimeInfo(float latitude, float longitude, int radius)
        {
            var bound = new bounds();
            double l = 1000 * 111;
            double latx = radius / l;
            double lagx = latx / Math.Cos(latitude);
            bound.latN = latitude + Math.Abs(latx);
            bound.latS = latitude - Math.Abs(latx);
            bound.lagE = longitude + Math.Abs(lagx);
            bound.lagW = longitude - Math.Abs(lagx);

            List<RealTimeInfoDeserialize> realtimeList = (from o in _db.RealTimeTable
                                                         where Convert.ToDouble(o.y1) <= bound.latN &&
                                                         Convert.ToDouble(o.y1) >= bound.latS &&
                                                         Convert.ToDouble(o.x1) <= bound.lagE &&
                                                         Convert.ToDouble(o.x1) >= bound.lagW
                                                         select new RealTimeInfoDeserialize()
                                                         {
                                                             region = o.region,
                                                             srcdetail = o.srcdetail,
                                                             areaNm = o.areaNm,
                                                             UID = o.UID,
                                                             direction = o.direction,
                                                             y1 = o.y1,
                                                             happentime = o.happentime,
                                                             roadtype = o.roadtype,
                                                             road = o.road,
                                                             modDttm = o.modDttm,
                                                             comment = o.comment,
                                                             happendate = o.happendate,
                                                             x1 = o.x1
                                                         }).ToList();
            return realtimeList;
        }
    }

    public class bounds
    {
        public double latN { get; set; }
        public double latS { get; set; }
        public double lagE { get; set; }
        public double lagW { get; set; }
    }


}