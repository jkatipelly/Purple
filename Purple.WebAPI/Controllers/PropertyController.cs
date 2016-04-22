using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Purple.Business;
using Purple.Entities;
using AttributeRouting;
using AttributeRouting.Web.Http;
using Purple.WebAPI.Filters;

namespace Purple.WebAPI.Controllers
{
    
    public class PropertyController : ApiController
    {
        private readonly IPropertyBusiness _propertyBusiness;


        /// <summary>
        /// public constructor to initialize property business instance
        /// </summary>
        public PropertyController(IPropertyBusiness propertyBusiness)
        {
            _propertyBusiness = propertyBusiness;
        }
        
        // GET: api/Property
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            var properties = _propertyBusiness.GetAllProperties();
            if (properties != null)
            {
                var propertyEntities = properties as List<Property> ?? properties.ToList();
                if (propertyEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, propertyEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound,"properties not found");
        }


        // GET: api/Property/5
        [AllowAnonymous]       
        public HttpResponseMessage Get(int id)
        {
            var property = _propertyBusiness.GetPropertyById(id);
            if (property != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, property);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No property found for this id");
        }

        // POST: api/Property
        [ApiAuthenticationFilter]
        public int Post([FromBody]Property property)
        {
            return _propertyBusiness.CreateProperty(property);
        }

        // PUT: api/Property/5
        [ApiAuthenticationFilter]
        public bool Put(int id, [FromBody]Property property)
        {
            return _propertyBusiness.UpdateProperty(id,property);
        }

        // DELETE: api/Property/5
        [ApiAuthenticationFilter]
        public bool Delete(int id)
        {
            if (id > 0)
            {
                return _propertyBusiness.DeleteProperty(id);
            }
            return false;
        }
    }
}
