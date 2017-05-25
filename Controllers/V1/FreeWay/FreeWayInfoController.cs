using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;

namespace Taoyuan_Traffic.Controllers.V1.FreeWay
{
    public class FreeWayInfoController : Controller
    {
        // GET: FreeWayInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFreeWayInfo()
        {
            //Initialize
            IFreeWay repos = DataFactory.FreeWayRespository();

            //return radius range Info
            return Content(JsonConvert.SerializeObject(repos.GetFreeWayInfo()), "application/json");
        }
    }
}