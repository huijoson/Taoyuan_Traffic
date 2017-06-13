using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels;

namespace Taoyuan_Traffic.Controllers.V1.Bus
{
    public class BusEstimateController : Controller
    {
        // GET: BusEstimate
        public async Task<ActionResult> Index()
        {
            //var BusRouteSource = await GetBusRouteData();
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusEstimatedTimeURL"].ToString() + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusEstimatedTimeDeserialize>>(response);
            IBusRoute repos = DataFactory.BusRouteRepository();

            //將JSON反序列化的資料填進資料庫中
            repos.AddBusEstimate(collection);

            return View();
        }
    }
}