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
    public class TraStationController : Controller
    {
        // GET: TraStation
        // GET: TraLine
        public async Task<ActionResult> Index()
        {
            var traStationSource = await new TraPubFunc().GetTraStaionData();
            //將JSON反序列化的資料填進資料庫中
            using (ITraLine repos = DataFactory.TraRepository())
            {
                repos.AddStation(traStationSource);
            }
            return View();
        }
    }
}