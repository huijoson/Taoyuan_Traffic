using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Weather;

namespace Taoyuan_Traffic.Models.Repository
{
    public class WeatherRespository : IWeather
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
        public WeatherRespository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public WeatherRespository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~WeatherRespository()
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

        public void addWeatherInfo(IEnumerable<Weather3DayDeserialize> weatherInfoSource)
        {
            var count = 1;
            
            _db.ExecuteCommand("DELETE FROM WeatherTable");
            foreach (Weather3DayDeserialize item in weatherInfoSource)
            {
                int elementCount = item.weatherElement.Count();
                for (var i=0; i<=elementCount-1; i++) {
                    int timeCount = item.weatherElement[i].time.Count();
                    for(var j=0; j<=timeCount-1; j++) {
                        var newWeather = new WeatherTable();
                        newWeather.wID = count;
                        newWeather.locationName = item.locationName;
                        newWeather.geocode = item.geocode;
                        newWeather.lat = item.lat;
                        newWeather.lon = item.lon;
                        newWeather.elementName = item.weatherElement[i].elementName;
                        newWeather.elementMeasure = item.weatherElement[i].elementMeasure;
                        newWeather.startTime = item.weatherElement[i].time[j].startTime;
                        newWeather.endTime = item.weatherElement[i].time[j].endTime;
                        newWeather.elementValue = item.weatherElement[i].time[j].elementValue;
                        if (item.weatherElement[i].time[j].parameter != null)
                        {
                            newWeather.parameterName = item.weatherElement[i].time[j].parameter[0].parameterName;
                            newWeather.parameterValue = item.weatherElement[i].time[j].parameter[0].parameterValue;
                        }
                        //newWeather.parameterName = item.weatherElement[i].time[j].parameter[0].parameterName;
                        //newWeather.parameterValue = item.weatherElement[i].time[j].parameter[0].parameterValue;
                        newWeather.dataTime = item.weatherElement[i].time[j].dataTime;

                        
                        _db.WeatherTable.InsertOnSubmit(newWeather);
                        _db.SubmitChanges();
                        count++;
                    }
                }
            }
        }
    }
}