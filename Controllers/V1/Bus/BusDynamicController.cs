﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.ViewModels;
using Taoyuan_Traffic.Models.Interface;
using System.Configuration;
using System.Web.Http;

namespace Taoyuan_Traffic.Controllers.V1.Bus
{
    public class BusDynamicController : Controller
    {
        /// <summary>
        /// 動態公車項目
        /// </summary>
        /// <returns></returns>

        // GET: BusDynamic
        public async Task<ActionResult> Index()
        {
            var BusDynamicSource = await new BusPubFunc().GetBusDynamicData();
            //將JSON反序列化的資料填進資料庫中
            using (IBusDynamic repos = DataFactory.BusDynamicRepository())
            {
                repos.AddBusInfo(BusDynamicSource);
            }
           
             
            return View();
        }
        /// <summary>
        /// 取得路線公車動態資訊
        /// </summary>
        /// <param name="routeName"></param>
        /// <returns></returns>
        public async Task<ActionResult> JsonRouteBusInfo(string routeName)
        {
            //Setting target Url
            string targetURI = ConfigurationManager.AppSettings["BusDynamicInfoURL"].ToString() + "/" + routeName.ToString() + "?$format=JSON";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            //Get Json String
            var response = await client.GetStringAsync(targetURI);
            //Deserialize
            var collection = JsonConvert.DeserializeObject<IEnumerable<BusDynamicDeserialize>>(response);

            IBusDynamic repos = DataFactory.BusDynamicRepository();

            return Content(JsonConvert.SerializeObject(repos.GetBusDynamicInfo(collection)), "application/json");
        }
    }
}