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
    public class BusDynamicController : Controller
    {
        
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

        public async Task<IEnumerable<BusDynamicDeserialize>> RetriveBusDynamicData(string cacheName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusDynamicURL"].ToString() + "?$top=5000&$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusDynamicDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0.2);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }

        // GET: BusDynamic
        public async Task<ActionResult> Index()
        {
            var BusDynamicSource = await this.GetBusDynamicData();
            //將JSON反序列化的資料填進資料庫中
            using (IBusDynamic repos = DataFactory.BusDynamicRepository())
            {
                repos.AddBusInfo(BusDynamicSource);
            }
            IEnumerable<BusDynamic> record;
            DataClassesDataContext db = new DataClassesDataContext();
            

                ViewData.Model = BusDynamicSource;

                record = (from o in db.BusDynamic select o).AsEnumerable();
             
                return View(record);
        }
    }
}