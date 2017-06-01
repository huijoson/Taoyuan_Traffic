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
using Taoyuan_Traffic.ViewModels.Rest;

namespace Taoyuan_Traffic.Controllers.V1.Rest
{
    public class RestController : ApiController
    {
        /// <summary>
        /// 取得兩輪充電站資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Rest/GetRestInfo")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(RestDeserialize))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得充電站資訊")]
        public IHttpActionResult GetRestInfo()
        {
            //Initial
            IHttpActionResult responseResult;
            IRest repos = DataFactory.RestRepository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetRestInfo());
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
