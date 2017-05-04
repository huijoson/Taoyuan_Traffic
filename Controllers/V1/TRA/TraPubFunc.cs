using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using Taoyuan_Traffic.ViewModels.TRA;

namespace Taoyuan_Traffic.Controllers.V1.TRA
{
    public class TraPubFunc
    {
        //車站路線用快取
        public async Task<IEnumerable<TraLineDeserialize>> GetTraData()
        {
            //setting cache
            string cacheName = "BusCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveTraData(cacheName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<TraLineDeserialize>;
            }
        }

        public async Task<IEnumerable<TraLineDeserialize>> RetriveTraData(string cacheName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["TraLineURL"].ToString();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<TraLineDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0.2);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }

        //車站資訊用快取
        public async Task<IEnumerable<TraStationDeserialize>> GetTraStaionData()
        {
            //setting cache
            string cacheName = "BusCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveTraStaionData(cacheName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<TraStationDeserialize>;
            }
        }

        public async Task<IEnumerable<TraStationDeserialize>> RetriveTraStaionData(string cacheName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["TraStaionURL"].ToString();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<TraStationDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0.2);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }

        //車種資訊用快取
        public async Task<IEnumerable<TraClassDeserialize>> GetTraClassData()
        {
            //setting cache
            string cacheName = "BusCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveTraClassData(cacheName);
            }
            else
            {
                return cacheContents.Value as IEnumerable<TraClassDeserialize>;
            }
        }

        public async Task<IEnumerable<TraClassDeserialize>> RetriveTraClassData(string cacheName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["TraClassURL"].ToString();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<TraClassDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0.2);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }

        //特定車次取得(起站、終站、日期、時間)
        public async Task<IEnumerable<TraDailyTimeTableDeserialize>> GetTraDTTData(string OriginSation, string Destionation, string TrainDate)
        {
            //setting cache
            string cacheName = "BusCache";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cacheName);

            if (cacheContents == null)
            {
                return await RetriveTraDTTData(cacheName, OriginSation, Destionation, TrainDate);
            }
            else
            {
                return cacheContents.Value as IEnumerable<TraDailyTimeTableDeserialize>;
            }
        }

        public async Task<IEnumerable<TraDailyTimeTableDeserialize>> RetriveTraDTTData(string cacheName, string OriginSation, string Destionation, string TrainDate)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["TraDailyTimetableURL"].ToString() + OriginSation + "/to/" + Destionation + "/" 
                + TrainDate + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<TraDailyTimeTableDeserialize>>(response);
            //setting cache policy
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(0.2);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cacheName, collection, policy);

            return collection;
        }

    }
}