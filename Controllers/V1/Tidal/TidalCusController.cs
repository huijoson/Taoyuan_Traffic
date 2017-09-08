using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Tidal;
using Taoyuan_Traffic.ViewModels.Weather;

namespace Taoyuan_Traffic.Controllers.V1.Tidal
{
    public class TidalCusController : Controller
    {
        // GET: TidalCus
        public ActionResult Index()
        {
            //Initial Variables
            ITidal repos = DataFactory.TidalRepository();
            repos.clearTidalTable();
            List<string> tList = new List<string> { "金門縣金城鎮", "金門縣金沙鎮", "金門縣金湖鎮", "金門縣金寧鄉", "金門縣烈嶼鄉", "金門縣烏坵鄉" };
            //Dictionary<int, string> wtD = new Dictionary<int, string>();

            //clear DataTable from DB
            repos.clearTidalTable();

            int rCount = 1;
            DateTime now = DateTime.Now;

            //string targetURI = ConfigurationManager.AppSettings["WeatherInfoURL"].ToString() + "/?elementName=Wx,PoP,T,CI&sort=time";
            //Add Json Data to SQL

            for (int i = 0; i <= tList.Count - 1; i++)
            {

                string targetURI = ConfigurationManager.AppSettings["TidalInfoURL"].ToString()
                    + "/" + "F-A0021-001?locationName=" + tList[i].ToString() + "&sort=datatime";

                var jsonResponse = "";
                StringBuilder jsonResultSB = new StringBuilder();

                //Get HTTPRequest RESPONSE Custom JSON FORMAT
                var webRequest = System.Net.WebRequest.Create(targetURI);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 900000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Authorization", "CWB-43A3A823-91B0-4D35-96E1-D66A1B5277AA");
                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            jsonResponse = sr.ReadToEnd();
                            JObject o = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                            jsonResultSB.Append(o.SelectToken("records").SelectToken("location[0].validTime").ToString());

                        }
                    }
                }

                //Deserialize
                var collection = JsonConvert.DeserializeObject<IEnumerable<TidalDeserialize>>(jsonResultSB.ToString());
                rCount = repos.addTidalInfo(collection, rCount, tList[i].ToString());

            }
            DateTime afterNow = DateTime.Now;
            string spendTime = (afterNow - now).ToString();
            return View();
        }
        /// <summary>
        /// 取得搜尋潮汐資訊(金門)
        /// </summary>
        /// <param name="local">鄉鎮地區關鍵字
        /// "金門縣金城鎮", "金門縣金沙鎮", "金門縣金湖鎮", "金門縣金寧鄉", "金門縣烈嶼鄉", "金門縣烏坵鄉"</param>
        /// <returns></returns>
        public ActionResult GetTidalInfo(string local = "金門縣金城鎮")
        {
            //Initial Variables
            ITidal repos = DataFactory.TidalRepository();
            return Content(JsonConvert.SerializeObject(repos.getTidalInfo(local)), "application/json");
        }
    }
}