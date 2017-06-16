using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.FreeWay;

namespace Taoyuan_Traffic.Controllers.V1.FreeWay
{
    public class FreeWayController : ApiController
    {
        /// <summary>
        /// 取得道路救援資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/FreeWay/GetFreeWay")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(FreeWayDeserialize))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得道路救援資訊")]
        public IHttpActionResult GetFreeWay()
        {
            //Initial
            IHttpActionResult responseResult;
            IFreeWay repos = DataFactory.FreeWayRepository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetFreeWayInfo());
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
