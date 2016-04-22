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
    public class OfferController : ApiController
    {

        private readonly IOfferBusiness _offerBusiness;

        public OfferController(IOfferBusiness offerBusiness)
        {
            _offerBusiness = offerBusiness;
        }
        // GET: api/Offer
        public HttpResponseMessage Get()
        {
            var offers = _offerBusiness.GetAllOffers();
            if (offers != null)
            {
                var offerEntities = offers as List<Offer> ?? offers.ToList();
                if (offerEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, offerEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "offers not found");
        }

        // GET: api/Offer/5
        public HttpResponseMessage Get(int id)
        {
            var offer = _offerBusiness.GetOfferById(id);
            if (offer != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, offer);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No property found for this id");
        }

        // POST: api/Offer
        public int Post([FromBody]Offer offer)
        {
            return _offerBusiness.CreateOffer(offer);
        }

        // PUT: api/Offer/5
        public bool Put(int id, [FromBody]Offer offer)
        {
            return _offerBusiness.UpdateOffer(id, offer);
        }

        // DELETE: api/Offer/5
        public bool Delete(int id)
        {
            return _offerBusiness.DeleteOffer(id);
        }
    }
}
