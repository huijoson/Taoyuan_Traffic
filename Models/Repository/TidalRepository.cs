using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Tidal;

namespace Taoyuan_Traffic.Models.Repository
{
    public class TidalRepository : ITidal
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
        public TidalRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public TidalRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~TidalRepository()
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


        public int addTidalInfo(IEnumerable<TidalDeserialize> tidalInfoSource, int rowCount, string localName)
        {

            var count = rowCount;


            foreach (TidalDeserialize item in tidalInfoSource)
            {
                int timeCount = item.weatherElement[2].time.Count();
                for (var j = 0; j <= timeCount - 1; j++)
                {
                    var newTidal = new Tidal();
                    newTidal.tidalID = count;
                    newTidal.locationName = localName;
                    //農曆
                    newTidal.chineseDateTimeName = item.weatherElement[0].elementName;
                    newTidal.chineseDateTime = item.weatherElement[0].elementValue;
                    //潮差
                    newTidal.tidalDiffName = item.weatherElement[1].elementName;
                    newTidal.tidalDiff = item.weatherElement[1].elementValue;

                    newTidal.dataTime = item.weatherElement[2].time[j].dataTime;
                    //潮汐
                    newTidal.tidalStatusName = item.weatherElement[2].time[j].parameter[0].parameterName;
                    newTidal.tidalStatus = item.weatherElement[2].time[j].parameter[0].parameterValue;
                    //潮高(TWVD)
                    newTidal.tidalTWVDName = item.weatherElement[2].time[j].parameter[1].parameterName;
                    newTidal.tidalTWVD = item.weatherElement[2].time[j].parameter[1].parameterValue +
                        item.weatherElement[2].time[j].parameter[1].parameterMeasure;
                    //潮高(當地)
                    newTidal.tidalLocalName = item.weatherElement[2].time[j].parameter[2].parameterName;
                    newTidal.tidalLocal = item.weatherElement[2].time[j].parameter[2].parameterValue +
                        item.weatherElement[2].time[j].parameter[2].parameterMeasure;
                    //潮高(相對海圖)
                    newTidal.tidalRelationSeaName = item.weatherElement[2].time[j].parameter[3].parameterName;
                    newTidal.tidalRelationSea = item.weatherElement[2].time[j].parameter[3].parameterValue +
                        item.weatherElement[2].time[j].parameter[3].parameterMeasure;

                    _db.Tidal.InsertOnSubmit(newTidal);
                    count++;
                }
            }
            _db.SubmitChanges();
            return count;
        }

        public List<TidalCusDeserialize> getTidalInfo(string keyWord)
        {
            List<TidalCusDeserialize> tidalList = (from o in _db.Tidal
                                             where  o.locationName.Contains(keyWord)
                                             orderby o.dataTime
                                             select new TidalCusDeserialize()
                                             {
                                                 locationName = o.locationName,
                                                 
                                                 chineseDate = o.chineseDateTime,
                                                 
                                                 tidalDiff = o.tidalDiff,
                                                 
                                                 dataTime = o.dataTime,
                                                 
                                                 tidalStatus = o.tidalStatus,
                                                 
                                                 tidalTWVD = o.tidalTWVD,
                                                 
                                                 tidalLocal = o.tidalLocal,
                                                 
                                                 tidalRelationSea = o.tidalRelationSea
                                             }).ToList();
            return tidalList;
        }

        public void clearTidalTable()
        {
            _db.ExecuteCommand("TRUNCATE TABLE Tidal");
        }
    }

}