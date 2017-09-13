using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taoyuan_Traffic.Controllers.V1.Token;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;

namespace Taoyuan_Traffic.Controllers.V1.Weather
{
    [JwtAuthActionFilter]
    public class WeatherController : ApiController
    {
        /// <summary>
        /// 取得一週天氣預報資訊
        /// </summary>
        /// <param name="attr">天氣屬性(           
        /// Wx:天氣示意, 
        /// PoP:降雨率, 
        /// T:溫度, 
        /// WeatherDescription:天氣敘述,
        /// Wind:風速、風向,
        /// UVI:紫外線)</param>
        /// <param name="date">日期(如:2017-05-26 21:00:00)</param>
        /// <param name="local">區域(如:桃園區)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Weather/GetSearchWeather")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得一週天氣預報資訊")]
        public IHttpActionResult GetSearchWeather(string attr, string local = "桃園區")
        {
            //Initial
            IHttpActionResult responseResult;
            IWeather repos = DataFactory.WeatherRepository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetWeatherSearch(attr, local));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
