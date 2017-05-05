using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Taoyuan_Traffic.Controllers.V1.Bus;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.TRA;

namespace Taoyuan_Traffic.Controllers.V1.TRA
{
    public class TraController : ApiController
    {
        /// <summary>
        /// 提供對應之時間火車時刻
        /// </summary>
        /// <remarks>
        /// 取得對應之去回時間後的火車班次
        /// </remarks>
        /// <param name="originSation">Go location</param>
        /// <param name="destionation">Back location</param>
        /// <param name="trainDate">Date</param>
        /// <param name="trainAfterTime">After The time to leave</param>
        /// <returns>HttpResponseMessages</returns>
        [HttpGet]
        [Route("api/v1/Tra/TraDailyTimeTable/GetTraDTT")]
        [ResponseType(typeof(TraDailyTimeTableDeserialize))]
        [SwaggerImplementationNotes("取得所有公車路線")]
        public async Task<IHttpActionResult> GetTraDTT(string originSation, string destionation, string trainDate, string trainAfterTime)
        {
            //Initial
            IHttpActionResult responseResult;
            ITraLine repos = DataFactory.TraRepository();
            string originSationID = repos.GetStationID(originSation);
            string destSationID = repos.GetStationID(destionation);
            var traDTTSource = await new TraPubFunc().GetTraDTTData(originSationID, destSationID, trainDate);
            //序列化撈出來的資料
            var jsonSerialize = JsonConvert.SerializeObject(
                repos.GetTraDailyTimetable(traDTTSource, trainAfterTime));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
