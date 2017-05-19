using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;

namespace Taoyuan_Traffic.Controllers.V1.RealTime
{
    public class RealTimeController : ApiController
    {
        /// <summary>
        /// 取得即時路況
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/ReealTime/GetReealTimeInfo")]
        //[ResponseType(typeof(Weather3DayDeserialize))]
        //[SwaggerImplementationNotes("取得所有公車路線")]
        public IHttpActionResult GetSearchWeather(float y, float x, int radius)
        {
            //Initial
            IHttpActionResult responseResult;
            IRealTime repos = DataFactory.RealTimeRespository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.getRealTimeInfo(y, x, radius));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
