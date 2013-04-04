using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MOOCollab.Contracts;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess.MOOCollabContext;

namespace MOOCollab.DataAccess.Repositories
{
    /// <summary>
    /// Generic abstract base repository, from which all repositories must be derived
    /// </summary>
    /// <typeparam name="T">Class representing the Domain Aggregate the repository supports.</typeparam>
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Provides access to the unit of work methods
        /// </summary>
        //        protected readonly DbContext Uow;//comes from UOW implementation
        private readonly DbContext _uow;

        /// <summary>
        /// Provides access to the entity set
        /// </summary>
        //  protected readonly DbSet<T> Set;

        protected IUow Uow { get { return _uow as IUow; } }
        protected DbSet<T> Set { get { return _uow.Set<T>(); } }
        protected DbContext Context { get { return _uow; } }

        /// <summary>
        /// Constructor: 
        /// </summary>
        /// <param name="UnitOfWork">Unit of Work, </param>
        public Repository(IUow UnitOfWork)
        {
            _uow = UnitOfWork as DbContext;  //assign MooCollabContext 
            //            Set = Uow.Set<T>();             //assign entity set
        }


        /// <summary>
        /// Return all methods in entity set
        /// </summary>
        /// <returns>
        /// Collection of IQueryable domain objects
        /// </returns>
        public virtual IQueryable<T> FindAll()
        {
            //            return Set;
            return _uow.Set<T>();
        }

        /// <summary>
        /// Provides a convient way of retrieving a graph of entities
        /// </summary>
        /// <param name="includeProperties">
        /// eg:courseRepository.AllIncluding(t => t.Owner,t => t.Groups, t => t.Students)
        /// </param>
        /// <returns>Collection of IQueryable domain objects</returns>
        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
              //referance to all entities of this type
            IQueryable<T> query = _uow.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                //add type to be included
                query = query.Include(includeProperty);
            }
            return query;//return graph
        }

        /// <summary>
        /// Find entity by id.  Will most likely need to be overridden as
        /// find is a method of the DbContext and any requirement to use 
        /// IQueryable extension methods such as Where or Include
        ///  will preclude its use
        /// </summary>
        /// <param name="id">Id of queried entity</param>
        /// <returns>
        /// Entity of T
        /// </returns>
        public virtual T Find(int id)
        {
            //            return Set.Find(id);
            return _uow.Set<T>().Find(id);
        }

        /// <summary>
        /// Uses the add method of the DbContext
        /// </summary>
        /// <param name="obj">
        /// new domain object
        /// </param>
        public virtual void Create(T obj)
        {
            //            Set.Add(obj);
            _uow.Set<T>().Add(obj);
        }

        /// <summary>
        /// Will attach the entered object to the context and mark it as changed
        /// </summary>
        /// <param name="obj">
        /// object to be updated
        /// </param>
        public virtual void Update(T obj)
        {
            //            Uow.Entry(obj).State = EntityState.Modified;
            _uow.Entry(obj).State = EntityState.Modified;
        }

        /// <summary>
        /// Will retrive an entity from the entity set and mark it
        /// for deletion
        /// </summary>
        /// <param name="id">
        /// int id of the entity
        /// </param>
        public virtual void Delete(int id)
        {
            //            var entry = Set.Find(id);
            var entry = _uow.Set<T>().Find(id);
            //            Uow.Entry(entry).State = EntityState.Deleted;
            _uow.Entry(entry).State = EntityState.Deleted;
        }

        /// <summary>
        /// Will attach an entity to the context and mark 
        /// the entity for deletion
        /// </summary>
        /// <param name="obj">
        /// domain object
        /// </param>
        public virtual void Delete(T obj)
        {
            //            Uow.Entry(obj).State = EntityState.Deleted;
            _uow.Entry(obj).State = EntityState.Deleted;
        }

        /// <summary>
        /// Saves all changes being tracked by the context
        /// </summary>
        public virtual void SaveChanges()
        {
            //            Uow.SaveChanges();
            _uow.SaveChanges();
        }

        ///// <summary>
        ///// Disposes the Unit of work.  Should not need to be called explicitly when using
        ///// ninject in request scope as the app is configured to OnePerRequestModule
        ///// <see cref="https://github.com/ninject/Ninject.Web.Common/wiki/InRequestScope"/>
        ///// </summary>
        //public virtual void Dispose()
        //{
        //    _uow.Dispose();
        //}
    }
}