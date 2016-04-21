using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purple.Entities;
using Purple.DAL.UnitOfWork;
using Purple.DAL;
using AutoMapper;
using System.Transactions;

namespace Purple.Business
{
    public class OfferBusiness : IOfferBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public OfferBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Offer GetOfferyById(int offerId)
        {
            var offer = _unitOfWork.OfferRepository.GetByID(offerId);
            if (offer != null)
            {
                Mapper.Initialize(cfg => { cfg.CreateMap<tblOffer, Offer>(); });
                var offerModel = Mapper.Map<tblOffer, Offer>(offer);
                return offerModel;
            }
            return null;
        }


        public int CreateOffer(Offer offer)
        {

            using (var scope = new TransactionScope())
            {
                var newOffer = new tblOffer
                {
                    PropertyID = offer.Property,
                    BuyerID = offer.Buyer,
                    SellerID = offer.Seller,
                    StatusID=offer.Status
                };

                _unitOfWork.OfferRepository.Insert(newOffer);
                _unitOfWork.Save();
                scope.Complete();
                return newOffer.OfferID;
            }

        }


        public IEnumerable<Offer> GetAllOffers()
        {
            var Offers = _unitOfWork.OfferRepository.GetAll().ToList();
            if (Offers.Any())
            {
                Mapper.Initialize(cfg => { cfg.CreateMap<tblOffer, Offer>(); });
                var OffersModel = Mapper.Map<List<tblOffer>, List<Offer>>(Offers);

                return OffersModel;
            }
            return null;

        }



        public bool UpdateOffer(Offer _offer)
        {
            var success = false;
            if (_offer != null)
            {
                using (var scope = new TransactionScope())
                {
                    var offer = _unitOfWork.OfferRepository.GetByID(_offer.OfferID);
                    if (offer != null)
                    {

                        offer.PropertyID = offer.PropertyID;
                        offer.BuyerID = offer.BuyerID;
                        offer.SellerID = offer.SellerID;
                        offer.StatusID = offer.StatusID;

                        _unitOfWork.OfferRepository.Update(offer);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteOffer(int OfferID)
        {
            var success = false;
            if (OfferID > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var offer = _unitOfWork.OfferRepository.GetByID(OfferID);
                    if (offer != null)
                    {
                        _unitOfWork.OfferRepository.Delete(offer);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

    }
}
