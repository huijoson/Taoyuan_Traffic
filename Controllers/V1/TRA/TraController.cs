using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Taoyuan_Traffic.Controllers.V1.TRA
{
    public class TraController : ApiController
    {
        // GET: api/Tra
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tra/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tra
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tra/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tra/5
        public void Delete(int id)
        {
        }
    }
}
