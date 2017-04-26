using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Taoyuan_Traffic.Controllers.V1
{
    /// <summary>
    /// 動態公車API
    /// </summary>
    public class BusAPIController : ApiController
    {
        // GET: api/BusAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BusAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BusAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BusAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BusAPI/5
        public void Delete(int id)
        {
        }
    }
}
