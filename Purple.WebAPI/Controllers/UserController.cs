using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Purple.Business;
using Purple.Entities;

namespace Purple.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserBusiness _userBusiness;

        public UserController()
        {
            _userBusiness = new UserBusiness();
        } 

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public HttpResponseMessage Get(int userID)
        {
            var user = _userBusiness.GetById(userID);
            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No property found for this id");
        }

        // POST: api/User
        public int Post([FromBody]User user)
        {
            return _userBusiness.RegisterUser(user);
        }

        // PUT: api/User/5
        public bool Put(int id, [FromBody]User user)
        {
            return _userBusiness.UpdateUser(id, user);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
