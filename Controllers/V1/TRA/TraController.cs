using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using System.Web.Http.Description;
using Taoyuan_Traffic.ViewModels.TRA;
using System.Threading.Tasks;

namespace Taoyuan_Traffic.Controllers.V1.TRA
{
    public class TraController : ApiController
    {
        /// <summary>
        /// 取得公車路線資料
        /// </summary>
        /// <param name="originSation">去</param>
        /// <param name="destionation">回</param>
        /// <param name="trainDate">乘車日期</param>
        /// <param name="trainAfterTime">乘車時間</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Tra/TraDailyTimeTable/GetRouteInfo")]
        [ResponseType(typeof(TraDailyTimeTableDeserialize))]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(TraDailyTimeTableDeserialize))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerImplementationNotes("取得台鐵路線及時刻資訊")]
        public async Task<IHttpActionResult> GetTraDailyTimeTable(string originSation, string destionation, string trainDate, string trainAfterTime)
        {

            //Initial
            IHttpActionResult responseResult;
            ITraLine repos = DataFactory.TraRepository();
            string originSationID = repos.GetStationID(originSation);
            string destSationID = repos.GetStationID(destionation);
            //反序列化從交通部撈出來的JSON
            var traDTTSource = await new TraPubFunc().GetTraDTTData(originSationID, destSationID, trainDate);
            //將需要的欄位取出後序列化
            var jsonSerialize = JsonConvert.SerializeObject(repos.GetTraDailyTimetable(traDTTSource, trainAfterTime));
            //做成JSON字串包裝到最後輸出
            StringContent responseMsgString = new StringContent(jsonSerialize, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = new HttpResponseMessage() { Content = responseMsgString };
            responseResult = ResponseMessage(responseMsg);

            return responseResult;
        }
    }
}
