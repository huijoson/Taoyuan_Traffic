using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Weather;

namespace Taoyuan_Traffic.Controllers.V1.Weather
{
    public class WeatherController : ApiController
    {
        /// <summary>
        /// 取得天氣資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Weather/GetSearchWeather")]
        //[ResponseType(typeof(Weather3DayDeserialize))]
        //[SwaggerImplementationNotes("取得所有公車路線")]
        public IHttpActionResult GetSearchWeather(string attr, string date, string local = "桃園區")
        {
            //Initial
            IHttpActionResult responseResult;
            IWeather repos = DataFactory.WeatherRespository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetWeatherSearch(attr, date, local));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
