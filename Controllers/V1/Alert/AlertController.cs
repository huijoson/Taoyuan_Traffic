using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
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
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Alert/GetAlertInfo")]
        [ResponseType(typeof(AlertInfo))]
        //[SwaggerImplementationNotes("取得所有公車路線")]
        public IHttpActionResult GetAlertInfo()
        {
            //Initial
            IHttpActionResult responseResult;
            IAlert repos = DataFactory.AlertRespository();
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(repos.getAlertInfo());
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
