using System;
using System.Linq;
using System.Linq.Expressions;

namespace MOOCollab.Contracts.RepositoryContracts
{
    /// <summary>
    /// Repository that is used by base context in order to provide common overridable
    /// functionality.  As the repository will be injected with a unit of work the interface
    /// must require any concrete implementation to supply save and dispose methods
    /// </summary>
    /// <typeparam name="T">The produced and stored by the repository</typeparam>
    public interface IRepository<T> where T : class
    {

        IQueryable<T> FindAll();
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeType);
        T Find(int id);
        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
        void Delete(T obj);
        void SaveChanges();     //  Only here to support CourseAdminController until the Save is moved to Repository
        //void Dispose();
    }
}
