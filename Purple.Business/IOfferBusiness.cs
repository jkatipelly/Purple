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
        Offer GetOfferyById(int offerId);
        IEnumerable<Offer> GetAllOffers();
        int CreateOffer(Offer offer);
        bool UpdateOffer(Offer offer);
        bool DeleteOffer(int OfferID);
    }
}
