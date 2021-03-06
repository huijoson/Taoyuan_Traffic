﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.FreeWay;

namespace Taoyuan_Traffic.Models.Repository
{
    public class FreeWayRepository : IFreeWay
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
        public FreeWayRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public FreeWayRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~FreeWayRepository()
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

        public List<FreeWayDeserialize> GetFreeWayInfo()
        {
            List<FreeWayDeserialize> FreeWayInfoList = (from o in _db.FreeWay
                                                    select new FreeWayDeserialize
                                                    {
                                                        rID = o.rID,
                                                        name = o.name.Trim().Replace(" ", ""),
                                                        addr = o.addr.Trim().Replace(" ",""),
                                                        phoneNum = o.phoneNum.Trim().Replace(" ", ""),
                                                        freephoneNum = o.freephoneNum.Trim().Replace(" ", ""),
                                                        smallCar = o.SmallCar,
                                                        largeCar = o.LargeCar
                                                    }).ToList();
            return FreeWayInfoList;
        }
    }
}