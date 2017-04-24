using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public class BusStopController : Controller
    {
        //用來暫存路線名稱
        public string routName = ""; 
        //取得路線資訊並設快取
        public async Task<IEnumerable<BusStopDeserialize>> GetBusStopData()
        {
            //setting cache
            string cacheName = "BusCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveBusStopData(cacheName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<BusStopDeserialize>;
            }
        }

        public async Task<IEnumerable<BusStopDeserialize>> RetriveBusStopData(string cacheName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusStopURL"].ToString() + "/" + routName + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusStopDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0.2);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }

        // GET: BusStop
        public async Task<ActionResult> Index()
        {
            var BusStopSource = await this.GetBusStopData();


            return View();
        }
        //取得公車站牌資訊(用路由名稱)
        public async Task<ActionResult> JsonBusStopInfo(string routeName)
        {
            routName = routeName;
            var busStopSource = await this.GetBusStopData();
            List<BusStopCustom> busStopList = new List<BusStopCustom>();
            IBusStop repos = DataFactory.BusStopRepository();
           

            return Content(JsonConvert.SerializeObject(repos.GetBusStop(busStopSource)),"application/json");
        }
    }
}