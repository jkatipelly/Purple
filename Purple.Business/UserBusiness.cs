using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purple.Entities;
using Purple.DAL.UnitOfWork;
using Purple.DAL;
using System.Transactions;

namespace Purple.Business
{
    public class UserBusiness : IUserBusiness
    {

        private readonly UnitOfWork _unitOfWork;

        public UserBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public bool Login(string username, string password)
        {
            var success = false;
           // int users = _unitOfWork.UserRepository.Get();

            //if (OfferID > 0)
            //{
            //    using (var scope = new TransactionScope())
            //    {
            //        var offer = _unitOfWork.OfferRepository.GetByID(OfferID);
            //        if (offer != null)
            //        {
            //            _unitOfWork.OfferRepository.Delete(offer);
            //            _unitOfWork.Save();
            //            scope.Complete();
            //            success = true;
            //        }
            //    }
            //}
            return success;

        }

        public int RegisterUser(User _user)
        {
            using (var scope = new TransactionScope())
            {
                var user = new tblUser
                {
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Password = _user.Password,
                    EmailAddress = _user.Email,
                    UserTypeID=_user.UserType
               
                };

                _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.Save();
                scope.Complete();
                return user.UserID;
            }
        }

        public bool UpdateUser(User _user)
        {
            var success = false;
            if (_user != null)
            {
                using (var scope = new TransactionScope())
                {
                    var user = _unitOfWork.UserRepository.GetByID(_user.UserID);
                    if (user != null)
                    {
                        user.FirstName = _user.FirstName;
                        user.LastName = _user.LastName;
                        user.Password = _user.Password;
                        user.EmailAddress = _user.Email;


                        _unitOfWork.UserRepository.Update(user);
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
