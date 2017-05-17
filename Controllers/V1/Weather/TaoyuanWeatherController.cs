using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Weather;

namespace Taoyuan_Traffic.Controllers.V1.Weather
{
    public class TaoyuanWeatherController : Controller
    {
        private String nowTime = DateTime.Now.ToString();
        // GET: TaoyuanWeathert
        public ActionResult Index()
        {
            //Initial Variables
            string targetURI = ConfigurationManager.AppSettings["WeatherInfoURL"].ToString() + "/?elementName=Wx,PoP,T,CI&sort=time";
            var jsonResponse = "";
            StringBuilder jsonResultSB = new StringBuilder();
            IWeather repos = DataFactory.WeatherRespository();
            
            //Get HTTPRequest RESPONSE Custom JSON FORMAT
            var webRequest = System.Net.WebRequest.Create(targetURI);
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.Timeout = 20000;
                webRequest.ContentType = "application/json";
                webRequest.Headers.Add("Authorization", "CWB-43A3A823-91B0-4D35-96E1-D66A1B5277AA");
                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        jsonResponse = sr.ReadToEnd();
                        JObject o = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                        //for (var i=0; i <= o.SelectToken("records").SelectToken("locations").Count(); i++) {
                        //    jsonResultSB.Append(o.SelectToken("records").SelectToken("locations["+i+"].location").ToString());
                        //}
                        jsonResultSB.Append(o.SelectToken("records").SelectToken("locations[0].location").ToString());

                    }
                }              
            }

            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<Weather3DayDeserialize>>(jsonResultSB.ToString());

            //Add Json Data to SQL
            repos.addWeatherInfo(collection);

            return View();
        }
        /// <summary>
        /// 取得搜尋天氣資訊
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="date"></param>
        /// <param name="local"></param>
        /// <returns></returns>
        public ActionResult GetSearchWeather(string attr, string date, string local = "桃園區")
        {
            //Initial Variables
            IWeather repos = DataFactory.WeatherRespository();
            return Content(JsonConvert.SerializeObject(repos.GetWeatherSearch(attr, date, local)), "application/json");
        }
    }
}