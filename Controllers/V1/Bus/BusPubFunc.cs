using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using Taoyuan_Traffic.ViewModels;

namespace Taoyuan_Traffic.Controllers.V1.Bus
{
    public class BusPubFunc
    {
        //站牌用快取
        public async Task<IEnumerable<BusStopDeserialize>> GetBusStopData(string routeName)
        {
            //setting cache
            string cacheName = "BusCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveBusStopData(cacheName, routeName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<BusStopDeserialize>;
            }
        }

        public async Task<IEnumerable<BusStopDeserialize>> RetriveBusStopData(string cacheName, string routeName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusStopURL"].ToString() + "/" + routeName + "?$format=JSON";
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

        //動態公車用快取
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
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0.2);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }
    }
}