using System;
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
        public static IParking ParkingRepository(DataClassesDataContext dataContext = null)
        {
            return new ParkingRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IWeather WeatherRepository(DataClassesDataContext dataContext = null)
        {
            return new WeatherRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IAlert AlertRepository(DataClassesDataContext dataContext = null)
        {
            return new AlertRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IRealTime RealTimeRepository(DataClassesDataContext dataContext = null)
        {
            return new RealTimeRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IUBike UBikeRepository(DataClassesDataContext dataContext = null)
        {
            return new UBikeRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IRest RestRepository(DataClassesDataContext dataContext = null)
        {
            return new RestRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static IFreeWay FreeWayRepository(DataClassesDataContext dataContext = null)
        {
            return new FreeWayRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        public static ITexi TexiRepository(DataClassesDataContext dataContext = null)
        {
            return new TexiRepository(dataContext);
        }

        /// <summary>
        /// 通用資料倉儲
        /// </summary>
        /// <param name="dataContext">資料實體</param>
        /// <returns>資料倉儲介面</returns>
        //public static IProduct ProductRepository(DataClassesDataContext dataContext = null)
        //{
        //    return new ProductRepositor(dataContext);
        //}
    }
}