﻿using System;
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
        void addWeatherInfo(IEnumerable<Weather3DayDeserialize> weatherInfoSource);
    }
}