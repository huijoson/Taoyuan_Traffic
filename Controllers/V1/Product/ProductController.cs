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
using Taoyuan_Traffic.ViewModels.FreeWay;
using Taoyuan_Traffic.ViewModels.Parking;

namespace Taoyuan_Traffic.Controllers.V1.Product
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        #region 公車資訊(全省)
        /// <summary>
        /// 取得所有公車路線(含關鍵字)
        /// </summary>
        /// <param name="cityType">Taipei: 1, NewTaipei: 2, Taoyuan: 3, Taichung: 4, Tainan: 5, 
        ///Kaohsiung: 6, Keelung: 7, Hsinchu: 8, HsinchuCounty: 9, MiaoliCounty: 10, 
        ///ChanghuaCounty: 11, NantouCounty: 12, YunlinCounty: 13, ChiayiCounty: 14, Chiayi: 15, 
        ///PingtungCounty: 16, YilanCounty: 17, HualienCounty: 18, TaitungCounty: 19, KinmenCounty: 20, 
        ///PenghuCounty: 21, PenghuCounty: 22</param>
        ///<param name="keyWord">關鍵字搜尋</param>
        /// <returns></returns>
        public List<GetRoute> GetRoute(int cityType, string keyWord)
        {
            IBusRoute repos = DataFactory.BusRouteRepository();
            return repos.GetRoute(cityType, keyWord);
        }
        /// <summary>
        /// 取得公車路線資料
        /// </summary>
        /// <param name="routeName">路線代號(如:137)</param>
        /// <param name="direction">去返</param>
        /// <returns></returns>
        public async Task<List<BusEstimatedTime>> GetBusEstimated(string city, string routeName = "", int direction = 0)
        {
            //initial variable
            DateTime now = DateTime.Now;
            IBusRoute repos = DataFactory.BusRouteRepository();
            int flag = 0;
            if (city == "Taipei")
            {
                flag = 1;
            }
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusEstimatedTimeURL"].ToString() + "/" + city + "/" + routeName + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusEstimatedTimeDeserialize>>(response);
            string afterNow = (DateTime.Now - now).ToString();
            return repos.GetBusEstimatedTime(collection, flag);
        }
        /// <summary>
        /// 取得路線公車動態資訊
        /// </summary>
        /// <param name="routeName"></param>
        /// <returns></returns>
        public async Task<List<ViewModels.BusDynamic>> GetDynamicBus(string cityEN, string routeName)
        {
            //initial variable
            DateTime now = DateTime.Now;
            IBusDynamic repos = DataFactory.BusDynamicRepository();

            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusDynamicInfoURL"].ToString() + "/" + cityEN + "/" + routeName + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusDynamicDeserialize>>(response);

            return repos.GetBusDynamicInfo(collection);
        }

        /// <summary>
        /// 取得公車站牌資訊
        /// </summary>
        /// <param name="routeName">路線代號</param>
        /// <returns></returns>
        public async Task<List<BusStopCustom>> GetBusStop(string cityEN, string routeName)
        {
            IBusStop repos = DataFactory.BusStopRepository();
            //Get Json String
            HttpClient client = new HttpClient();
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusStopURL"].ToString() + "/" + cityEN + "/" + routeName + "?$format=JSON";
            string response = await client.GetStringAsync(targetURI);
            //Deserialize
            var busStopSource = JsonConvert.DeserializeObject<IEnumerable<BusStopDeserialize>>(response);

            return repos.GetBusStop(busStopSource);
        }
        #endregion

        #region 災害資訊(全省)來源:警廣
        /// <summary>
        /// 取得災害警示資訊(全台)
        /// </summary>
        /// <param name="keyWord">鄉鎮區(如:桃園)</param>
        /// <returns></returns>
        public List<AlertInfo> GetAlertInfo(string keyWord)
        {
            //Initial Variables
            IAlert repos = DataFactory.AlertRepository();

            return repos.getAlertInfo(keyWord);
        }
        #endregion

        #region 取得道路救援資訊(全省國道)
        public List<FreeWayDeserialize> GetFreeWay()
        {
            //Initialize
            IFreeWay repos = DataFactory.FreeWayRepository();

            //return radius range Info
            return repos.GetFreeWayInfo();
        }
        #endregion

        #region 室外停車場資訊(桃園地區)
        public List<ParkingDeserialize> GetParking()
        {
            //Initialize
            IParking repos = DataFactory.ParkingRepository();

            return repos.GetOutParkingInfo();
        }
        #endregion


    }
}