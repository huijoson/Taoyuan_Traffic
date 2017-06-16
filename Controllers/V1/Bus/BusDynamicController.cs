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
using System.Web.Http;

namespace Taoyuan_Traffic.Controllers.V1.Bus
{
    public class BusDynamicController : Controller
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
        /// <summary>
        /// 動態公車項目
        /// </summary>
        /// <returns></returns>

        // GET: BusDynamic
        public async Task<ActionResult> Index()
        {
            var BusDynamicSource = await GetBusDynamicData();
            //將JSON反序列化的資料填進資料庫中
            using (IBusDynamic repos = DataFactory.BusDynamicRepository())
            {
                repos.AddBusInfo(BusDynamicSource);
            }
           
             
            return View();
        }
        /// <summary>
        /// 取得路線公車動態資訊
        /// </summary>
        /// <param name="routeName"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetDynamicBusInfo(string cityEN,string routeName)
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

            return Content(JsonConvert.SerializeObject(repos.GetBusDynamicInfo(collection)), "application/json");
        }

        public async Task<IEnumerable<BusDynamicDeserialize>> GetBusDynamicData()
        {
            //setting cache
            string cacheName = "BusCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveBusDynamicData(cacheName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<BusDynamicDeserialize>;
            }
        }
        //動態公車用快取
        public async Task<IEnumerable<BusDynamicDeserialize>> RetriveBusDynamicData(string cacheName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusDynamicURL"].ToString() + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusDynamicDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }
    }
}