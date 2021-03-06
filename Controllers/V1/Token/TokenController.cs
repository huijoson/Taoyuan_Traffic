﻿using Jose;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using Taoyuan_Traffic.Models;
using Taoyuan_Traffic.Models.Interface;
using Taoyuan_Traffic.ViewModels.Token;

namespace Taoyuan_Traffic.Controllers.V1.Token
{
    public class TokenController : ApiController
    {
        /// <summary>
        /// 取得Token資訊
        /// </summary>
        /// <param name="request">需用Post傳Header("X-Client-Uid")</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/Token")]
        [SwaggerImplementationNotes("取得Token資訊")]
        // POST api/values
        public object Post(HttpRequestMessage request)
        {
            //Init TokenClientInfo
            ClientInfo clientInfo = new ClientInfo();

            // TODO: key應該移至config
            clientInfo.secret = "CIANAPI";

            //Token ID
            clientInfo.clientID = GetClientID(request);

            //TODO: expiretime
            var now = DateTime.Now;
            clientInfo.expireTime = now.AddDays(1);

            //TODO: IP
            clientInfo.clientIP = GetClientIP();


            //TODO: repos
            IToken repos = DataFactory.TokenRepository();

            return repos.getToken(clientInfo);

        }

        /// <summary>
        /// 取得客戶端真實IP Address
        /// </summary>
        /// <returns>IP位址</returns>
        public static string GetClientIP()
        {
            string ip = "";

            if (HttpContext.Current == null) return ip;
            object x_forward = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (x_forward != null)
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString() == string.Empty || HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToUpper().IndexOf("UNKNOWN") > 0)
                {
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") > 0)
                {
                    ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") - 1);
                }
                else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") > 0)
                {
                    ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") - 1);
                }
                else
                {
                    ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }
            }
            else
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            return ip.Replace(" ", string.Empty);
        }

        public static string GetClientID(HttpRequestMessage request)
        {
            IEnumerable<string> clientID = request.Headers.GetValues("X-Client-Uid");
            var id = clientID.FirstOrDefault();

            return id;
        }
    }
}
