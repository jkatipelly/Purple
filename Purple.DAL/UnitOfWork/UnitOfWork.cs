using Purple.DAL.GenericRepository;
using Purple.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        private GenericRepository<tblUser> _userRepository;
        private GenericRepository<tblProperty> _PropertyRepository;
        private GenericRepository<tblOffer> _OfferRepository;
        #endregion


        
        public UnitOfWork()
        {
            _context = new PurpleEntities();
        }



        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for Property repository.
        /// </summary>
        public GenericRepository<tblProperty> PropertyRepository
        {
            get
            {
                if (this._PropertyRepository == null)
                    this._PropertyRepository = new GenericRepository<tblProperty>(_context);
                return _PropertyRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<tblUser> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<tblUser>(_context);
                return _userRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Offer repository.
        /// </summary>
        public GenericRepository<tblOffer> OfferRepository
        {
            get
            {
                if (this._OfferRepository == null)
                    this._OfferRepository = new GenericRepository<tblOffer>(_context);
                return _OfferRepository;
            }

        }


        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
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
