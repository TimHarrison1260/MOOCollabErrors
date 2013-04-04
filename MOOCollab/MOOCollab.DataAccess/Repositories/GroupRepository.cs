using MOOCollab.Contracts;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.Domain;
namespace MOOCollab.DataAccess.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        /// <summary>
        /// Calls to base Repository in order to ensure all repositories use 
        /// the correct unit of work.
        /// DbContext is reachable through the Context property.
        /// 
        /// DbSet is reachable through the Set property.
        /// </summary>
        /// <param name="uow">
        /// Implemetation of IUow of T injected using ninject
        /// </param>
        public GroupRepository(IUow uow)
            : base(uow)
        {
        }
    }
}