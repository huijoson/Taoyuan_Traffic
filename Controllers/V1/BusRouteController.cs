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

namespace Taoyuan_Traffic.Controllers
{
    public class BusRouteController : Controller
    {
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
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0.2);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }

        // GET: BusRoute
        public async Task<ActionResult> Index()
        {
            var BusRouteSource = await this.GetBusRouteData();
            //將JSON反序列化的資料填進資料庫中
            using (IBusRoute repos = DataFactory.BusRouteRepository())
            {
                repos.AddBusRoute(BusRouteSource);
            }
            IEnumerable<BusRoute> record;
            DataClassesDataContext db = new DataClassesDataContext();

            record = (from o in db.BusRoute select o).AsEnumerable();

            return View();
        }

        public ActionResult JsonAllRoute()
        {
            IBusRoute repos = DataFactory.BusRouteRepository();

            return Content(JsonConvert.SerializeObject(repos.GetAllRoute()), "application/json");
        }
        //取得公車路線資訊並轉成JSON輸出
        public async Task<ActionResult> JsonBusEstimatedInfo(string routeName,string direction = "0'%20or%20Direction%20eq%20%20'1")
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusEstimatedTimeURL"].ToString() +
                "/" + routeName + "?$filter=Direction%20eq%20'" + direction + "'&$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject(response);

            return Content(JsonConvert.SerializeObject(collection), "application/json");
        }
        //關鍵字搜尋公車路線
        public ActionResult JsonSearchRoute(string keyword)
        {
            IBusRoute repos = DataFactory.BusRouteRepository();

            return Content(JsonConvert.SerializeObject(repos.GetSearchRoute(keyword)), "application/json");
        }

    }
}