using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purple.Entities;
using Purple.DAL.UnitOfWork;
using Purple.DAL;
using System.Transactions;
using AutoMapper;

namespace Purple.Business
{
    public class UserBusiness : IUserBusiness
    {

        private readonly UnitOfWork _unitOfWork;

        public UserBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        ///Gets user based on Userid
        /// </summary>
        /// <param name="userID"></param>
     
        public User GetById(int userID)
        {
            var user = _unitOfWork.UserRepository.GetByID(userID);
            if (user != null)
            {
                Mapper.Initialize(cfg => { cfg.CreateMap<tblUser, User>(); });
                var userModel = Mapper.Map<tblUser, User>(user);
                return userModel;
            }
            return null;
        }


        /// <summary>
        /// Validating User Credentials against database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string username, string password)
        {
            var success = false;
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == username && u.Password== password && u.IsActive).FirstOrDefault();
           
            if (user != null)
            {
                success = true;
            }
            return user.UserID;
        }

        /// <summary>
        /// Registering user
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        public int RegisterUser(User _user)
        {
            using (var scope = new TransactionScope())
            {
                var user = new tblUser
                {
                    FirstName = _user.FirstName,
                    LastName = _user.LastName,
                    Password =_user.Password,
                    EmailAddress = _user.Email,
                    UserTypeID=_user.UserType,
                    IsActive=_user.IsActive,
                    UserName=_user.UserName               
                };

                _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.Save();
                scope.Complete();
                return user.UserID;
            }
        }
        /// <summary>
        /// Updating User Record, for updating details or to deactivate account
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        public bool UpdateUser(int userid, User _user)
        {
            var success = false;
            if (_user != null)
            {
                using (var scope = new TransactionScope())
                {
                    var user = _unitOfWork.UserRepository.GetByID(userid);
                    if (user != null)
                    {
                        user.FirstName = _user.FirstName;
                        user.LastName = _user.LastName;
                        user.Password = _user.Password;
                        user.EmailAddress = _user.Email;
                        user.IsActive = _user.IsActive;

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
