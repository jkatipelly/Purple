using Purple.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purple.Business
{
    public interface IOfferBusiness
    {
        Offer GetOfferById(int offerId);
        IEnumerable<Offer> GetAllOffers();
        int CreateOffer(Offer offer);
        bool UpdateOffer(int offerID,Offer offer);
        bool DeleteOffer(int OfferID);
    }
}
