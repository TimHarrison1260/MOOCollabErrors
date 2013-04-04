using System.Linq;
using MOOCollab.Domain;

namespace MOOCollab.Contracts.RepositoryContracts
{
    public interface IUserRepository :IRepository<User>
    {
        IQueryable<User> GetUsersForCourse(int id, string userName);
        IQueryable<User> GetUsersForGroup(int id, string userName);

        void FollowUser(int studentId, User userToFollow);
        void FollowUser(int studentId, int userIdToFollow);
        void FollowUser(string username, User userToFollow);
        void FollowUser(string userName, int userIdToFollow);

        void UnFollowUser(string username, User userToFollow);
        void UnFollowUser(string userName, int userIdToFollow);
    }
}
