using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Weather;

namespace Taoyuan_Traffic.Models.Repository
{
    public class WeatherRepository : IWeather
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
        public WeatherRepository()
        {
            this._db = new DataClassesDataContext();

        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        /// <param name="context">實體資料集合</param>
        public WeatherRepository(DataClassesDataContext context = null)
        {
            this._db = (context == null ? new DataClassesDataContext() : context);
        }

        /// <summary>
        /// 倉儲建構子
        /// </summary>
        ~WeatherRepository()
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

        public object GetWeatherSearch(string attr, string date, string local)
        {
            DateTime dt1 = Convert.ToDateTime(date);
            switch (attr)
            {
                case "Wx":
                    List<WeatherWx> weatherListWx = (from o in _db.WeatherTable
                                                       where o.elementName.Contains("Wx")
                                                       && (Convert.ToDateTime(o.startTime) > dt1)
                                                       && o.locationName.Contains(local)
                                                   select new WeatherWx()
                                                   {
                                                       startTime = o.startTime,
                                                       endTime = o.endTime,
                                                       elementValue = o.elementValue,
                                                       parameterName = o.parameterName,
                                                       parameterValue = o.parameterValue
                                                   }).ToList();
                    return weatherListWx;

                case "PoP":
                    List<WeatherPoP> weatherListPoP = (from o in _db.WeatherTable
                                                       where o.elementName.Contains("PoP")
                                                       && Convert.ToDateTime(o.startTime) > dt1
                                                       && o.locationName.Contains(local)
                                                   select new WeatherPoP()
                                                   {
                                                       startTime = o.startTime,
                                                       endTime = o.endTime,
                                                       elementValue = o.elementValue,
                                                       elementMeasure = o.elementMeasure
                                                   }).ToList();
                    return weatherListPoP;

                case "T":
                    List<WeatherT> weatherListT = (from o in _db.WeatherTable
                                                       where o.elementName.Contains("T")
                                                       && Convert.ToDateTime(o.dataTime) > dt1
                                                       && o.locationName.Contains(local)
                                                   select new WeatherT()
                                                     {
                                                         dataTime = o.dataTime,
                                                         elementValue = o.elementValue,
                                                         elementMeasure = o.elementMeasure
                                                     }).ToList();
                    return weatherListT;

                case "CI":
                    List<WeatherCI> weatherListCI = (from o in _db.WeatherTable
                                                   where o.elementName.Contains("CI")
                                                   && Convert.ToDateTime(o.dataTime) > dt1
                                                   && o.locationName.Contains(local)
                                                   select new WeatherCI()
                                                   {
                                                       dataTime = o.dataTime,
                                                       elementValue = o.elementValue,
                                                       parameterValue = o.parameterValue,
                                                       parameterName = o.parameterName
                                                   }).ToList();
                    return weatherListCI;

                default:
                    return null;
            }
        }

    }
}