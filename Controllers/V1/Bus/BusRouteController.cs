using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.ViewModels;
using Taoyuan_Traffic.Models.Interface;
using System.Configuration;

namespace Taoyuan_Traffic.Controllers.V1.Bus
{
    /// <summary>
    /// 公車路線資訊
    /// </summary>
    public class BusRouteController : Controller
    {
        //Taipei: 1, NewTaipei: 2, Taoyuan: 3, Taichung: 4, Tainan: 5, 
        //Kaohsiung: 6, Keelung: 7, Hsinchu: 8, HsinchuCounty: 9, MiaoliCounty: 10, 
        //ChanghuaCounty: 11, NantouCounty: 12, YunlinCounty: 13, ChiayiCounty: 14, Chiayi: 15, 
        //PingtungCounty: 16, YilanCounty: 17, HualienCounty: 18, TaitungCounty: 19, KinmenCounty: 20, 
        //PenghuCounty: 21, PenghuCounty: 22
        List<string> listCity = new List<string> { "Taipei", "NewTaipei", "Taoyuan", "Taichung", "Tainan", "Kaohsiung",
                                                        "Keelung", "Hsinchu", "HsinchuCounty", "MiaoliCounty", "ChanghuaCounty",
                                                        "NantouCounty", "YunlinCounty", "ChiayiCounty", "Chiayi", "PingtungCounty",
                                                        "YilanCounty", "HualienCounty", "TaitungCounty", "KinmenCounty", "PenghuCounty",
                                                        "PenghuCounty" };
        // GET: BusRoute
        public async Task<ActionResult> Index()
        {
            //initial variable
            DateTime now = DateTime.Now;
            int count = 1;
            IBusRoute repos = DataFactory.BusRouteRepository();
            repos.clearBusRouteTable();

            for (int i=0; i<= listCity.Count-1; i++) {
                //Setting target Url
                string targetURI = ConfigurationManager.AppSettings["BusRouteURL"].ToString() + "/" + listCity[i] + "?$format=JSON";
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = Int32.MaxValue;
                //Get Json String
                var response = await client.GetStringAsync(targetURI);
                //Deserialize
                var collection = JsonConvert.DeserializeObject<IEnumerable<BusRouteDeserialize>>(response);
                
                //將JSON反序列化的資料填進資料庫中
                count = repos.AddBusRoute(collection, count, i+1);
            }
            string afterNow = (DateTime.Now-now).ToString();
            return Content("公車路線取得時間:" + afterNow);
        }
        /// <summary>
        /// 取得公車路線
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoute(string city, string keyword="")
        {
            IBusRoute repos = DataFactory.BusRouteRepository();
            Dictionary<string, int> dicCity = new Dictionary<string, int>();
            for (int i = 0; i <= listCity.Count - 1; i++)
            {
                dicCity.Add(listCity[i], i + 1);
            }

            return Content(JsonConvert.SerializeObject(repos.GetRoute(dicCity.ContainsKey(city)?dicCity[city]:1, keyword)), "application/json");
        }
        /// <summary>
        /// 取得公車路線資訊並轉成JSON輸出
        /// </summary>
        /// <param name="city">鄉鎮英文</param>
        /// <param name="routeName">公車路線名稱</param>
        /// <param name="direction">去、返(0、1)</param>
        /// <returns></returns>
        public async Task<ActionResult> GetBusEstimatedTime(string city, string routeName = "", int direction = 0)
        {
            //initial variable
            DateTime now = DateTime.Now;
            IBusRoute repos = DataFactory.BusRouteRepository();
            int flag = 0;
            if(city == "Taipei")
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
            return Content(JsonConvert.SerializeObject(repos.GetBusEstimatedTime(collection, flag)), "application/json");
        }
        /// <summary>
        /// 關鍵字搜尋公車路線
        /// </summary>
        /// <param name="keyword">關鍵字(路線名稱、路線代號)</param>
        /// <returns></returns>
        public ActionResult JsonSearchRoute(string keyword)
        {
            IBusRoute repos = DataFactory.BusRouteRepository();

            return Content(JsonConvert.SerializeObject(repos.GetSearchRoute(keyword)), "application/json");
        }

        //公車路線用快取
        public async Task<IEnumerable<BusRouteDeserialize>> GetBusRouteData()
        {
            //setting cache
            string cacheName = "BusCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveBusRouteData(cacheName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<BusRouteDeserialize>;
            }
        }

        public async Task<IEnumerable<BusRouteDeserialize>> RetriveBusRouteData(string cacheName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusRouteURL"].ToString() + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusRouteDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }
    }
}