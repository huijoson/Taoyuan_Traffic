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

        /// <summary>
        /// 取得所有公車路線
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Bus/BusRoute/GetAllRoute")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(GetRoute))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得所有公車路線資訊")]
        public IHttpActionResult GetAllRoute()
        {
            //Initial
            IHttpActionResult responseResult;
            IBusRoute repos = DataFactory.BusRouteRepository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetAllRoute());
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }

        /// <summary>
        /// 取得公車路線資料
        /// </summary>
        /// <param name="routeName">路線代號(如:137)</param>
        /// <param name="direction">去返</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Bus/BusRoute/GetRouteInfo")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(BusEstimatedTimeDeserialize))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得公車路線資料")]
        public async Task<IHttpActionResult> GetBusEstimatedInfo(string routeName, string direction = "0'%20or%20Direction%20eq%20%20'1")
        {
            //Initial
            IHttpActionResult responseResult;
            IBusRoute repos = DataFactory.BusRouteRepository();
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusEstimatedTimeURL"].ToString() +
                "/" + routeName + "?$filter=Direction%20eq%20'" + direction + "'&$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //反序列化從交通部撈出來的JSON
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
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetBusDynamicInfo(collection));
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
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(BusDynamicDeserialize))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得公車站牌資訊")]
        public async Task<IHttpActionResult> GetBusStopInfo(string routeName = "")
        {
            //Initial
            IHttpActionResult responseResult;
            IBusStop repos = DataFactory.BusStopRepository();
            //Get Json String
            var busStopSource = await new BusStopController().GetBusStopData(routeName);
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

