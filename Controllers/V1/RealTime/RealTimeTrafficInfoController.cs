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
using Taoyuan_Traffic.ViewModels.RealTime;

namespace Taoyuan_Traffic.Controllers.V1.RealTime
{
    public class RealTimeTrafficInfoController : Controller
    {
        // GET: RealTimeTrafficInfo
        public async Task<ActionResult> Index()
        {
            //Initialize
            IRealTime repos = DataFactory.RealTimeRespository();
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["RealTimeInfoURL"].ToString();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Parking Json Format (not completed json)
            var response = await client.GetStringAsync(targetURI);
            JObject o = (JObject)JsonConvert.DeserializeObject(response);
            string parkString = o.SelectToken("result").ToString();
            //將JSON反序列化的資料填進資料庫中
            var collection = JsonConvert.DeserializeObject<IEnumerable<RealTimeInfoDeserialize>>(parkString);
            repos.addRealTimeInfo(collection);

            return View();
        }

        public ActionResult GetRealTime(float y, float x, int radius)
        {

            //Initialize
            IRealTime repos = DataFactory.RealTimeRespository();
            
            //return radius range Info
            return Content(JsonConvert.SerializeObject(repos.getRealTimeInfo(y, x, radius)), "application/json");
        }
        
        
    }


}