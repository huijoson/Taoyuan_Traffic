using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels;
using Taoyuan_Traffic.ViewModels.Alert;

namespace Taoyuan_Traffic.Controllers.V1.Product
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        #region 公車資訊
        /// <summary>
        /// 取得所有公車路線
        /// </summary>
        /// <returns></returns>
        //public List<GetRoute> GetRouteInfo()
        //{
        //    IBusRoute repos = DataFactory.BusRouteRepository();
        //    return repos.GetAllRoute();
        //}
        /// <summary>
        /// 取得公車路線資料
        /// </summary>
        /// <param name="routeName">路線代號(如:137)</param>
        /// <param name="direction">去返</param>
        ///// <returns></returns>
        //public List<BusEstimatedTime> GetBusEstimatedInfo(string routeName, int direction = 0)
        //{
        //    IBusRoute repos = DataFactory.BusRouteRepository();
        //    return repos.GetBusEstimatedTime(routeName, direction);
        //}
        /// <summary>
        /// 關鍵字搜尋公車路線
        /// </summary>
        /// <param name="keyword">關鍵字(路線名稱、路線代號)</param>
        /// <returns></returns>
        public List<GetRoute> GetSearchRoute(string keyword)
        {
            IBusRoute repos = DataFactory.BusRouteRepository();
            return repos.GetSearchRoute(keyword);
        }

        /// <summary>
        /// 取得路線公車動態資訊
        /// </summary>
        /// <param name="routeName"></param>
        /// <returns></returns>
        public List<ViewModels.BusDynamic> GetDynamicBusInfo(string routeName)
        {
            IBusDynamic repos = DataFactory.BusDynamicRepository();
            return repos.GetBusDynamicInfo(routeName);
        }

        /// <summary>
        /// 取得公車站牌資訊
        /// </summary>
        /// <param name="routeName">路線代號</param>
        /// <returns></returns>
        public async Task<List<BusStopCustom>> GetBusStopInfo(string routeName)
        {
            IBusStop repos = DataFactory.BusStopRepository();
            //Get Json String
            HttpClient client = new HttpClient();
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusStopURL"].ToString() + "/" + routeName + "?$format=JSON";
            string response = await client.GetStringAsync(targetURI);
            //Deserialize
            var busStopSource = JsonConvert.DeserializeObject<IEnumerable<BusStopDeserialize>>(response);

            return repos.GetBusStop(busStopSource);
        }
        #endregion 公車資訊
        #region 災害資訊
        public List<AlertInfo> GetAlertInfo(string keyWord)
        {
            IAlert repos = DataFactory.AlertRepository();
            return repos.getAlertInfo(keyWord);
        }
        #endregion 災害資訊
    }
}