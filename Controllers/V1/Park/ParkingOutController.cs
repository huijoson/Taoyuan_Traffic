using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels;
using Taoyuan_Traffic.ViewModels.Parking;

namespace Taoyuan_Traffic.Controllers.V1.PARK
{
    public class ParkingOutController : Controller
    {
        // GET: Parking
        public async Task<ActionResult> Index()
        {

            //Initialize
            IParking repos = DataFactory.ParkingRepository();

            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["ParkingInfoURL"].ToString();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Parking Json Format (not completed json)
            var response = await client.GetStringAsync(targetURI);
            JObject o = (JObject)JsonConvert.DeserializeObject(response);
            string parkString = o.SelectToken("result").SelectToken("records").ToString();

            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<ParkingDeserialize>>(parkString);

            //Add Parking Info
            repos.AddOutParking(collection);

            return View();
        }


        public ActionResult JsonParkingInfo()
        {   
            //Initialize
            IParking repos = DataFactory.ParkingRepository();

            return Content(JsonConvert.SerializeObject(repos.GetOutParkingInfo()), "application/json");
        }

        

        //動態公車用快取
        public async Task<IEnumerable<ParkingDeserialize>> GetParkingData()
        {
            //setting cache
            string cacheName = "ParkingCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveParkingData(cacheName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<ParkingDeserialize>;
            }
        }

        public async Task<IEnumerable<ParkingDeserialize>> RetriveParkingData(string cacheName)
        {
            //Setting target Url
            string targetURI = "http://data.tycg.gov.tw/api/v1/rest/datastore/0daad6e6-0632-44f5-bd25-5e1de1e9146f?format=json";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<ParkingDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0.5);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }
    }
}