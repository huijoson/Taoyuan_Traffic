using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels;

namespace Taoyuan_Traffic.Controllers.V1.Bus
{
    /// <summary>
    /// Bus
    /// </summary>
    public class BusController : ApiController
    {
        //用來暫存路線名稱
        public string routName = "";

        //Taipei: 1, NewTaipei: 2, Taoyuan: 3, Taichung: 4, Tainan: 5, 
        //Kaohsiung: 6, Keelung: 7, Hsinchu: 8, HsinchuCounty: 9, MiaoliCounty: 10, 
        //ChanghuaCounty: 11, NantouCounty: 12, YunlinCounty: 13, ChiayiCounty: 14, Chiayi: 15, 
        //PingtungCounty: 16, YilanCounty: 17, HualienCounty: 18, TaitungCounty: 19, KinmenCounty: 20, 
        //PenghuCounty: 21, PenghuCounty: 22
        List<string> listCity = new List<string> { "Taipei", "NewTaipei", "Taoyuan", "Taichung", "Tainan", "Kaohsiung",
                                                        "Keelung", "Hsinchu", "HsinchuCounty", "MiaoliCounty", "ChanghuaCounty",
                                                        "NantouCounty", "YunlinCounty", "ChiayiCounty", "Chiayi", "PingtungCounty",
                                                        "YilanCounty", "HualienCounty", "TaitungCounty", "KinmenCounty", "PenghuCounty",
                                                        "LienchiangCounty" };
        /// <summary>
        /// 取得所有公車路線
        /// </summary>
        /// <param name="city">鄉政英文名稱 Taipei: 1, NewTaipei: 2, Taoyuan: 3, Taichung: 4, Tainan: 5, 
        ///         Kaohsiung: 6, Keelung: 7, Hsinchu: 8, HsinchuCounty: 9, MiaoliCounty: 10, 
        ///         ChanghuaCounty: 11, NantouCounty: 12, YunlinCounty: 13, ChiayiCounty: 14, Chiayi: 15,
        ///         PingtungCounty: 16, YilanCounty: 17, HualienCounty: 18, TaitungCounty: 19, KinmenCounty: 20,
        ///         PenghuCounty: 21, PenghuCounty: 22</param>
        /// <param name="keyword">關鍵字</param>
        /// <returns></returns> 
        [HttpGet]                        
        [Route("api/v1/Bus/BusRoute/GetRoute")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(GetRoute))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得所有公車路線資訊")]
        public IHttpActionResult GetRoute(string city, string keyword="")
        {
            //Initial
            IHttpActionResult responseResult;
            IBusRoute repos = DataFactory.BusRouteRepository();
            Dictionary<string, int> dicCity = new Dictionary<string, int>();
            for (int i = 0; i <= listCity.Count - 1; i++)
            {
                dicCity.Add(listCity[i], i + 1);
            }
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetRoute(dicCity.ContainsKey(city) ? dicCity[city] : 1, keyword));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }

        /// <summary>
        /// 取得公車到站資料
        /// </summary>
        /// <param name="city">鄉鎮英文</param>
        /// <param name="routeName">公車路線名稱</param>
        /// <param name="direction">去、返(0、1)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Bus/BusRoute/GetBusEstimatedTime")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(BusEstimatedTime))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得公車到站資料")]
        public async Task<IHttpActionResult> GetBusEstimatedTime(string city, string routeName = "", int direction = 0)
        {
            //initial variable
            IHttpActionResult responseResult;
            DateTime now = DateTime.Now;
            IBusRoute repos = DataFactory.BusRouteRepository();
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusEstimatedTimeURL"].ToString() + "/" + city + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusEstimatedTimeDeserialize>>(response);
            //將需要的欄位取出後序列化
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetBusEstimatedTime(collection));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }

        /// <summary>
        /// 關鍵字搜尋公車路線
        /// </summary>
        /// <param name="keyword">關鍵字(路線名稱、路線代號)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Bus/BusRoute/GetSearchRoute")]
        [ResponseType(typeof(GetRoute))]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(GetRoute))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("關鍵字搜尋公車路線")]
        public IHttpActionResult GetSearchRoute(string keyword)
        {
            //Initial
            IHttpActionResult responseResult;
            IBusRoute repos = DataFactory.BusRouteRepository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetSearchRoute(keyword));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }

        /// <summary>
        /// 取得路線公車動態資訊
        /// </summary>
        /// <param name="routeName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Bus/BusRoute/GetDynamicBusInfo")]
        [ResponseType(typeof(BusDynamicDeserialize))]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(BusDynamicDeserialize))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得路線公車動態資訊")]
        public async Task<IHttpActionResult> GetDynamicBusInfo(string routeName)
        {
            //Initial
            IHttpActionResult responseResult;
            IBusDynamic repos = DataFactory.BusDynamicRepository();
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusDynamicInfoURL"].ToString() + "/" + routeName.ToString() + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusDynamicDeserialize>>(response);
            //將需要的欄位取出後序列化
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetBusDynamicInfo(routeName));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }

        /// <summary>
        /// 取得公車站牌資訊
        /// </summary>
        /// <param name="routeName">路線代號</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Bus/BusRoute/GetBusStopInfo")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(BusStopCustom))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得公車站牌資訊")]
        public async Task<IHttpActionResult> GetBusStopInfo(string routeName = "")
        {
            //Initial
            IHttpActionResult responseResult;
            IBusStop repos = DataFactory.BusStopRepository();
            //Get Json String
            HttpClient client = new HttpClient();
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusStopURL"].ToString() + "/" + routeName + "?$format=JSON";
            string response = await client.GetStringAsync(targetURI);
            //Deserialize
            var busStopSource = JsonConvert.DeserializeObject<IEnumerable<BusStopDeserialize>>(response);
            //將需要的欄位取出後序列化
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetBusStop(busStopSource));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);


            return responseResult;
        }
    }
}

