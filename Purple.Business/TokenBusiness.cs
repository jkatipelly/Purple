using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purple.DAL.UnitOfWork;
using Purple.DAL;
using Purple.Entities;
namespace Purple.Business
{
    public class TokenBusiness : ITokenBusiness
    {

        private readonly UnitOfWork _unitOfWork;


        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public TokenBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public bool DeleteByUserId(int userId)
        {
            //TODO :Implementation
            throw new NotImplementedException();
        }

        public Token GenerateToken(int userId)
        {
            //TODO :Implementation
            throw new NotImplementedException();
        }

        public bool Kill(string tokenId)
        {
            //TODO :Implementation
            throw new NotImplementedException();
        }

        public bool ValidateToken(string tokenId)
        {
            //TODO :Implementation
            throw new NotImplementedException();
        }
    }
}
