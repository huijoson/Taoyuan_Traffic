using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taoyuan_Traffic.Controllers.V1.Token;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Tidal;

namespace Taoyuan_Traffic.Controllers.V1.Tidal
{
    public class TidalController : ApiController
    {
        [JwtAuthActionFilter]
        /// <summary>
        /// 取得一個月份潮汐資料(金門地區)
        /// </summary>
        /// <param name="local">鄉鎮地區關鍵字
        /// "金門縣金城鎮", "金門縣金沙鎮", "金門縣金湖鎮", "金門縣金寧鄉", "金門縣烈嶼鄉", "金門縣烏坵鄉"</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Tidal/GetSearchTidal")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(TidalCusDeserialize))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得金門一個月份潮汐資訊(以今天)")]
        public IHttpActionResult GetSearchTidal(string local = "金門縣金城鎮")
        {
            //Initial
            IHttpActionResult responseResult;
            ITidal repos = DataFactory.TidalRepository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.getTidalInfo(local));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
