using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Alert;

namespace Taoyuan_Traffic.Models.Repository
{
    public class AlertRepository : IAlert
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
        public AlertRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public AlertRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~AlertRepository()
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

        public void AddAlertInfo(IEnumerable<AlertDeserialize> alertResource)
        {
            var count = 1;
            _db.ExecuteCommand("DELETE FROM AlertTable");
            foreach (AlertDeserialize item in alertResource)
            {
                var newAlertClass = new AlertTable
                {
                    alertID = count,
                    updated = item.updated,
                    name = item.author.name,
                    text = item.summary.text.Replace('\n',' ').Trim(),
                    term = item.category.term
                };
                count++;
                _db.AlertTable.InsertOnSubmit(newAlertClass);
                _db.SubmitChanges();
            }
        }

        public List<AlertInfo> getAlertInfo()
        {
            List<AlertInfo> alertList = (from o in _db.AlertTable
                                         select new AlertInfo()
                                         {
                                             updated = o.updated.Value,
                                             name = o.name,
                                             text = o.text,
                                             term = o.term
                                         }).ToList();
            return alertList;
        }
    }
}