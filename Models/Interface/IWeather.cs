using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.ViewModels.Weather;

namespace Taoyuan_Traffic.Models.Interface
{
    public interface IWeather : IDisposable
    {
        /// <summary>
        /// 傳回使用的資料庫實體
        /// </summary>
        DataClassesDataContext Entity { get; }

        /// <summary>
        /// 新增天氣資訊
        /// </summary>
        int addWeatherInfo(IEnumerable<Weather3DayDeserialize> weatherInfoSource, int rowCount);
        /// <summary>
        /// 取得搜尋的天氣資訊
        /// </summary>
        /// <param name="attr">天氣屬性</param>
        /// <param name="date">日期時間</param>
        /// <returns></returns>
        object GetWeatherSearch(string attr, string local);
        void clearWTTable();
    }
}