﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.Models.Repository;

namespace Taoyuan_Traffic.Models
{
    public class DataFactory
    {

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IBusDynamic BusDynamicRepository(DataClassesDataContext dataContext = null)
        {
            return new BusDynamicRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IBusRoute BusRouteRepository(DataClassesDataContext dataContext = null)
        {
            return new BusRouteRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IBusStop BusStopRepository(DataClassesDataContext dataContext = null)
        {
            return new BusStopRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static ITraLine TraRepository(DataClassesDataContext dataContext = null)
        {
            return new TraRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IParking ParkingRespository(DataClassesDataContext dataContext = null)
        {
            return new ParkingRespository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IWeather WeatherRespository(DataClassesDataContext dataContext = null)
        {
            return new WeatherRespository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IAlert AlertRespository(DataClassesDataContext dataContext = null)
        {
            return new AlertRespository(dataContext);
        }
    }
}