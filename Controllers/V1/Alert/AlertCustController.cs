using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Alert;

namespace Taoyuan_Traffic.Controllers.V1.Alert
{
    public class AlertCustController : Controller
    {
        // GET: AlertCust
        public async Task<ActionResult> Index()
        {
            //Initialize
            IAlert repos = DataFactory.AlertRepository();
            

            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["AlertInfoURL"].ToString();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Parking Json Format (not completed json)
            var response = await client.GetStringAsync(targetURI);
            JObject o = (JObject)JsonConvert.DeserializeObject(response);
            StringBuilder sb = new StringBuilder(o.SelectToken("entry").ToString());
            string alertString = sb.Replace("#", string.Empty).Replace("@", string.Empty).ToString();
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<AlertDeserialize>>(alertString);
            //Add Alert Info
            repos.AddAlertInfo(collection);

            return View();
        }
        /// <summary>
        /// 取得災害警示資訊
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAlertInfo(string keyWord)
        {
            //Initial Variables
            IAlert repos = DataFactory.AlertRepository();
            return Content(JsonConvert.SerializeObject(repos.getAlertInfo(keyWord)), "application/json");
        }
        //災害防變用快取
        public async Task<IEnumerable<AlertDeserialize>> GetAlertData()
        {
            //setting cache
            string cacheName = "AlertCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveAlertData(cacheName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<AlertDeserialize>;
            }
        }
        public async Task<IEnumerable<AlertDeserialize>> RetriveAlertData(string cacheName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["AlertInfoURL"].ToString();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<AlertDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }
    }
}