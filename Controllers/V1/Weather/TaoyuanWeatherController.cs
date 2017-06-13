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
            IWeather repos = DataFactory.WeatherRepository();
            List<string> wtList = new List<string> { "F-D0047-003", "F-D0047-007", "F-D0047-011", "F-D0047-015", "F-D0047-019", "F-D0047-023", "F-D0047-027"
            , "F-D0047-031", "F-D0047-035", "F-D0047-039", "F-D0047-043", "F-D0047-047", "F-D0047-051", "F-D0047-055", "F-D0047-059", "F-D0047-063"
            , "F-D0047-067", "F-D0047-071", "F-D0047-075", "F-D0047-079", "F-D0047-083", "F-D0047-087"};
            //Dictionary<int, string> wtD = new Dictionary<int, string>();
            //clear DataTable from DB
            repos.clearWTTable();
            int rCount = 1;
            DateTime now = DateTime.Now;
            //string targetURI = ConfigurationManager.AppSettings["WeatherInfoURL"].ToString() + "/?elementName=Wx,PoP,T,CI&sort=time";
            for (int i = 0; i <= wtList.Count-1; i++)
            {

                string targetURI = ConfigurationManager.AppSettings["WeatherInfoURL"].ToString() + "/" 
                                    + wtList[i].ToString() + "?elementName=WeatherDescription,Wx,PoP,T&sort=time";

                var jsonResponse = "";
                StringBuilder jsonResultSB = new StringBuilder();


                //Get HTTPRequest RESPONSE Custom JSON FORMAT
                var webRequest = System.Net.WebRequest.Create(targetURI);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 50000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Authorization", "CWB-43A3A823-91B0-4D35-96E1-D66A1B5277AA");
                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            jsonResponse = sr.ReadToEnd();
                            JObject o = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                            jsonResultSB.Append(o.SelectToken("records").SelectToken("locations[0].location").ToString());

                        }
                    }
                }

                //Deserialize
                var collection = JsonConvert.DeserializeObject<IEnumerable<Weather3DayDeserialize>>(jsonResultSB.ToString());

                //Add Json Data to SQL
                rCount = repos.addWeatherInfo(collection, rCount);
            }
            DateTime afterNow = DateTime.Now;
            string spendTime = (afterNow - now).ToString();
            return Content(spendTime);
        }
        /// <summary>
        /// 取得搜尋天氣資訊
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="date"></param>
        /// <param name="local"></param>
        /// <returns></returns>
        public ActionResult GetSearchWeather(string attr, DateTime date, string local = "桃園區")
        {
            //Initial Variables
            IWeather repos = DataFactory.WeatherRepository();
            return Content(JsonConvert.SerializeObject(repos.GetWeatherSearch(attr, date, local)), "application/json");
        }
    }
}