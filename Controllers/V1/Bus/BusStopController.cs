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
using System.Web.Http;

namespace Taoyuan_Traffic.Controllers.V1.Bus
{
    /// <summary>
    /// 站牌資訊
    /// </summary>
    public class BusStopController : Controller
    {   

        // GET: BusStop
        public async Task<ActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// 取得公車站牌資訊
        /// </summary>
        /// <param name="routeName">路線名稱</param>
        /// <returns></returns>
        public async Task<ActionResult> JsonBusStopInfo(string routeName)
        {
            IBusStop repos = DataFactory.BusStopRepository();
            //Get Json String
            HttpClient client = new HttpClient();
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusStopURL"].ToString() + "/" + routeName + "?$format=JSON";
            string response = await client.GetStringAsync(targetURI);
            //Deserialize
            var busStopSource = JsonConvert.DeserializeObject<IEnumerable<BusStopDeserialize>>(response);           

            return Content(JsonConvert.SerializeObject(repos.GetBusStop(busStopSource)),"application/json");
        }
    }
}