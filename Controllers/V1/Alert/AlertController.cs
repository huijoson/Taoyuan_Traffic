using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Alert;

namespace Taoyuan_Traffic.Controllers.V1.Alert
{
    public class AlertController : ApiController
    {
        /// <summary>
        /// 取得災害警示資訊
        /// </summary>
        /// <param name="keyWord">鄉鎮區(如:桃園)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Alert/GetAlertInfo")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(AlertInfo))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得災害警示資訊")]
        //[SwaggerImplementationNotes("取得所有公車路線")]
        public IHttpActionResult GetAlertInfo(string keyWord)
        {
            //Initial
            IHttpActionResult responseResult;
            IAlert repos = DataFactory.AlertRepository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.getAlertInfo(keyWord));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
