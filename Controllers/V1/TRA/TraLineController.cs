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
    public class TraLineController : Controller
    {
        // GET: TraLine
        public async Task<ActionResult> Index()
        {
            var traLineSource = await new TraPubFunc().GetTraData();
            //將JSON反序列化的資料填進資料庫中
            using (ITraLine repos = DataFactory.TraRepository())
            {
                repos.AddTraLine(traLineSource);
            }
            return View();
        }

        public ActionResult JsonTraLine()
        {
            ITraLine repos = DataFactory.TraRepository();

            return Content(JsonConvert.SerializeObject(repos.GetTraLine()), "application/json");
        }
    }
}