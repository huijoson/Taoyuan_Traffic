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
using Taoyuan_Traffic.ViewModels.Ubike;

namespace Taoyuan_Traffic.Controllers.V1.UBike
{
    public class UBikeController : ApiController
    {
        /// <summary>
        /// 取得YouBike資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/UBike/GetUBikeInfo")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(UBikeDeserialize))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得YouBike資訊")]
        public IHttpActionResult GetUBikeInfo()
        {
            //Initial
            IHttpActionResult responseResult;
            IUBike repos = DataFactory.UBikeRespository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetUbikeInfo());
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }




}
