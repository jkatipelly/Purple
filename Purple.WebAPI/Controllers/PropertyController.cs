using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Purple.WebAPI.Controllers
{
    public class PropertyController : ApiController
    {
        // GET: api/Property
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Property/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Property
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Property/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Property/5
        public void Delete(int id)
        {
        }
    }
}
