#region Using Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
#endregion

namespace Purple.DAL.GenericRepository
{
    /// <summary>
    /// Generic Repository class for Entity Operations
    /// </summary>
    public class GenericRepository<TEntity> where TEntity:class
    {
        internal PurpleEntities Context;
        internal DbSet<TEntity> DbSet;


        /// <summary>
        /// Public Constructor,initializes privately declared local variables.
        /// </summary>
        public GenericRepository(PurpleEntities _context)
        {
            this.Context = _context;
            this.DbSet = Context.Set<TEntity>();
        }

        /// <summary>
        /// generic Get method for Entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }

        /// <summary>
        /// Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// generic method to fetch all the records from db
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }


        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(TEntity entity)
        {
            TEntity entityToDelete = DbSet.Find(entity);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
