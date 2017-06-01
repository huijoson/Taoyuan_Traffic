using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Ubike;

namespace Taoyuan_Traffic.Controllers.V1.UBike
{
    public class UBikeInfoController : Controller
    {
        // GET: UBikeInfo
        public async Task<ActionResult> Index()
        {
            //Initialize
            IUBike repos = DataFactory.UBikeRepository();


            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["UBikeInfoURL"].ToString();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Parking Json Format (not completed json)
            var response = await client.GetStringAsync(targetURI);
            JObject o = (JObject)JsonConvert.DeserializeObject(response);
            StringBuilder sb = new StringBuilder(o.SelectToken("result").SelectToken("records").ToString());
            string uBikeString = sb.Replace("#", string.Empty).Replace("@", string.Empty).ToString();
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<UBikeDeserialize>>(uBikeString);
            //Add Alert Info
            repos.AddUBikeInfo(collection);

            return View();
        }

        public ActionResult GetUBikeInfo()
        {
            //Initial Variables
            IUBike repos = DataFactory.UBikeRepository();
            return Content(JsonConvert.SerializeObject(repos.GetUbikeInfo()), "application/json");
        }
    }
}