using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.RealTime;

namespace Taoyuan_Traffic.Controllers.V1.RealTime
{
    public class RealTimeController : ApiController
    {
        /// <summary>
        /// 取得即時路況(全台)
        /// </summary>
        /// <param name="radius">半徑範圍(公尺)</param>
        /// <param name="x">經度</param>
        /// <param name="y">緯度</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/RealTime/GetRealTimeInfo")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(RealTimeInfoDeserialize))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得即時路況資訊")]
        public IHttpActionResult GetSearchWeather(float y, float x, int radius)
        {
            //Initial
            IHttpActionResult responseResult;
            IRealTime repos = DataFactory.RealTimeRepository();
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
