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
using Taoyuan_Traffic.ViewModels.Rest;

namespace Taoyuan_Traffic.Controllers.V1.Rest
{
    public class RestInfoController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //Initialize
            IRest repos = DataFactory.RestRepository();


            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["RestInfoURL"].ToString();
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Parking Json Format (not completed json)
            var response = await client.GetStringAsync(targetURI);
            JObject o = (JObject)JsonConvert.DeserializeObject(response);
            StringBuilder sb = new StringBuilder(o.SelectToken("result").SelectToken("records").ToString());
            string uBikeString = sb.Replace("#", string.Empty).Replace("@", string.Empty).ToString();
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<RestDeserialize>>(uBikeString);
            //Add Alert Info
            repos.AddRestInfo(collection);

            return View();
        }

        public ActionResult GetRestInfo()
        {
            //Initial Variables
            IRest repos = DataFactory.RestRepository();

            return Content(JsonConvert.SerializeObject(repos.GetRestInfo()), "application/json");
        }
    }
}