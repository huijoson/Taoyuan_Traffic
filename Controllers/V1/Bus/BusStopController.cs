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

namespace Taoyuan_Traffic.Controllers.V1.Bus
{
    /// <summary>
    /// 站牌資訊
    /// </summary>
    public class BusStopController : Controller
    {
        //用來暫存路線名稱
        public string routName = ""; 
        

        // GET: BusStop
        public async Task<ActionResult> Index()
        {
            var BusStopSource = await new BusPubFunc().GetBusStopData(routName);


            return View();
        }

        /// <summary>
        /// 取得公車站牌資訊
        /// </summary>
        /// <param name="routeName">路線名稱</param>
        /// <returns></returns>
        public async Task<ActionResult> JsonBusStopInfo(string routeName)
        {
            var busStopSource = await new BusPubFunc().GetBusStopData(routName);
            IBusStop repos = DataFactory.BusStopRepository();
           

            return Content(JsonConvert.SerializeObject(repos.GetBusStop(busStopSource)),"application/json");
        }
    }
}