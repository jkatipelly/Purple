using Purple.DAL.GenericRepository;
using Purple.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purple.DAL.UnitOfWork
{
    public class UnitOfWork:IDisposable
    {

        #region Private member variables...

        private PurpleEntities _context = null;
        private GenericRepository<User> _userRepository;
        private GenericRepository<Property> _PropertyRepository;
        private GenericRepository<Offer> _OfferRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new PurpleEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<Property> PropertyRepository
        {
            get
            {
                if (this._PropertyRepository == null)
                    this._PropertyRepository = new GenericRepository<Property>(_context);
                return _PropertyRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<User>(_context);
                return _userRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public GenericRepository<Offer> OfferRepository
        {
            get
            {
                if (this._OfferRepository == null)
                    this._OfferRepository = new GenericRepository<Offer>(_context);
                return _OfferRepository;
            }

        }
        #endregion


        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
                
                disposedValue = true;
            }
        }
             
        public void Dispose()
        {
            
            Dispose(true);           
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
