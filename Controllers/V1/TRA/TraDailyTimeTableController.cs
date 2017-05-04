using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;

namespace Taoyuan_Traffic.Controllers.V1.TRA
{
    public class TraDailyTimeTableController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var traDTTSource = await new TraPubFunc().GetTraClassData();
            //將JSON反序列化的資料填進資料庫中
            using (ITraLine repos = DataFactory.TraRepository())
            {
                //repos.GetTraDailyTimetable(traDTTSource);
            }
            return View();
        }

        public async Task<ActionResult> GetTraDTT(string originSation, string destionation, string trainDate, string trainAfterTime)
        {
            ITraLine repos = DataFactory.TraRepository();

            string originSationID = repos.GetStationID(originSation);
            string destSationID = repos.GetStationID(destionation);


            var traDTTSource = await new TraPubFunc().GetTraDTTData(originSationID, destSationID, trainDate);

            return Content(JsonConvert.SerializeObject(repos.GetTraDailyTimetable(traDTTSource, trainAfterTime)), "application/json");
        }
    }
}