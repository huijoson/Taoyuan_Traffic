using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Rest;

namespace Taoyuan_Traffic.Models.Repository
{
    public class RestRepository : IRest
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
        public RestRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public RestRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~RestRepository()
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

        public void AddRestInfo(IEnumerable<RestDeserialize> addUBikeResource)
        {
            _db.ExecuteCommand("DELETE FROM RestTable");
            foreach (RestDeserialize item in addUBikeResource)
            {
                var newRestInfo = new RestTable
                {
                    _id = item._id,
                    OpenTime = item.營業時間,
                    PhoneNum = item.電話,
                    Class = item.類別,
                    Addr = item.地址,
                    Name = item.名稱,
                    Vocation = item.休假日,
                    Area = item.區域,

                };
                _db.RestTable.InsertOnSubmit(newRestInfo);
                _db.SubmitChanges();
            }
        }

        public List<RestDeserialize> GetRestInfo()
        {
            List<RestDeserialize> RestInfoList = (from o in _db.RestTable
                                                    select new RestDeserialize
                                                    {
                                                        _id = o._id,
                                                        營業時間 = o.OpenTime,
                                                        電話 = o.PhoneNum,
                                                        類別 = o.Class,
                                                        地址 = o.Addr,
                                                        名稱 = o.Name,
                                                        休假日 = o.Vocation,
                                                        區域 = o.Area,
                                                    }).ToList();
            return RestInfoList;
        }
    }
}