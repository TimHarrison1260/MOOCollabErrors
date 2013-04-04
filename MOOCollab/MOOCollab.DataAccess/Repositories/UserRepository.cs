using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MOOCollab.Contracts;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.Domain;

namespace MOOCollab.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
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
        /// 
        //  Change to reference IMOOCollabContext instead of concrete uow
        //  IMOOCollabContext is just the IUow interface
        public UserRepository(IUow UnitOfWork)
            : base(UnitOfWork)
        {
        }

        /// <summary>
        /// Get a list of Users that belong to a course, excluding the user who is logged on.
        /// </summary>
        /// <param name="id">The Id of the Course</param>
        /// <param name="userName">The UserName of the logged on user</param>
        /// <returns>Returns a collection of Users</returns>
        public IQueryable<User> GetUsersForCourse(int id, string userName)
        {
            //  Select all students for the specified course Id and return.
            //  NB.  There are no include statements here as there is no nees
            //  to retrieve any related entities, we are working purely with
            //  User entities, once the Course entity has allowed the Users
            //  for a course to be identified.
            //  NB  Also, we are excluding the current user (logged on), which
            //  is identified by the UserName which is unique.  This avoids the
            //  need to transpose the UserName to a UserId.
            var answer = Uow.Courses.Where(c => c.Id == id).SelectMany(s => s.Students).Where(s => s.UserName != userName);
            return answer;
        }

        /// <summary>
        /// Get a list of Users that belong to a Group, excluding the user who is logget on.
        /// </summary>
        /// <param name="id">The id of the Group</param>
        /// <param name="userName">The UserName of the logged on user</param>
        /// <returns>Returns a collection of Users</returns>
        public IQueryable<User> GetUsersForGroup(int id, string userName)
        {
            //  See comments for GetStudentsForCourse.

            //  Cast to the correct type, MOOCollab2Context to get access to the model.
            //var moocollabContext = Uow as MOOCollab2Context;
            //  Get list of Users belonging to Group.
            var result = Uow.Groups.Where(g => g.Id == id).SelectMany(s => s.Members).Where(s => s.UserName != userName);
            return result;
        }



        #region FollowUser Overloads

        /// <summary>
        /// Adds the logged on user, specified by the UserId, as a follower of the other User.
        /// </summary>
        /// <param name="userId">The id of the logged on user, the follower.</param>
        /// <param name="userToFollow">The User that is being followed</param>
        public void FollowUser(int userId, User userToFollow)
        {
            //  Cast to the correct type, MOOCollab2Context to get access to the model.
            //            var moocollabContext = Uow as MOOCollab2Context;
            //var moocollabContext = _uow.Context;
            //            var me = moocollabContext.Students.FirstOrDefault(s => s.Id == studentId);
            var me = Set.FirstOrDefault(s => s.Id == userId);
            UpdateUser(me, userToFollow);
        }

        /// <summary>
        /// Adds the logged on user, specified by the UserId, as a follower of the other User.
        /// </summary>
        /// <param name="userId">The id of the logged on user, the follower.</param>
        /// <param name="userIdToFollow">The id of the user that is being followed</param>
        public void FollowUser(int userId, int userIdToFollow)
        {
            //  Cast to the correct type, MOOCollab2Context to get access to the model.
            //            var moocollabContext = Uow as MOOCollab2Context;
            //var moocollabContext = _uow.Context;
            //var userToFollow = moocollabContext.Students.FirstOrDefault(s => s.Id == userIdToFollow);
            var userToFollow = Set.FirstOrDefault(s => s.Id == userIdToFollow);
            this.FollowUser(userId, userToFollow);
        }

        /// <summary>
        /// Adds the logged on user, specified by the Username, as a follower of the other user.
        /// </summary>
        /// <param name="userName">The Username of the logged on user, the follower</param>
        /// <param name="userToFollow">The user that is being followed</param>
        public void FollowUser(string userName, User userToFollow)
        {
            //  Cast to the correct type, MOOCollab2Context to get access to the model.
            //            var moocollabContext = Uow as MOOCollab2Context;
            //var moocollabContext = _uow.Context;
            //var me = moocollabContext.Students.FirstOrDefault(s => s.UserName == userName);
            var me = Set.FirstOrDefault(s => s.UserName == userName);
            UpdateUser(me, userToFollow);
        }

        /// <summary>
        /// Adds the logged on user, specified by the Username, as a follower of the other user.
        /// </summary>
        /// <param name="userName">The Username of the logged on user, the follower.</param>
        /// <param name="userIdToFollow">The id of the user that is being followed.</param>
        public void FollowUser(string userName, int userIdToFollow)
        {
            //  Cast to the correct type, MOOCollab2Context to get access to the model.
            //            var moocollabContext = Uow as MOOCollab2Context;
            //var moocollabContext = _uow.Context;
            //var userToFollow = moocollabContext.Students.FirstOrDefault(s => s.Id == userIdToFollow);
            var userToFollow = Set.FirstOrDefault(s => s.Id == userIdToFollow);
            this.FollowUser(userName, userToFollow);
        }

        #endregion


        #region UnFollowUser Overloads

        /// <summary>
        /// Removes the logged on user, specified by the UserName, from following the other user
        /// </summary>
        /// <param name="userName">The userName of the logged on user, the follower</param>
        /// <param name="userIdToUnfollow">The Id of the user that is currently being followed.</param>
        public void UnFollowUser(string userName, int userIdToUnfollow)
        {
            var userToUnfollow = Set.FirstOrDefault(u => u.Id == userIdToUnfollow);
            UnFollowUser(userName, userToUnfollow);
        }

        /// <summary>
        /// Removes the logged on user, specified by the UserName, from following the other user
        /// </summary>
        /// <param name="userName">The User name of the logged on user, the follower.</param>
        /// <param name="userToUnfollow">The User that is currently being followed.</param>
        public void UnFollowUser(string userName, User userToUnfollow)
        {
            var me = Set.FirstOrDefault(u => u.UserName == userName);
            RemoveUser(me, userToUnfollow);
        }


        #endregion

        /// <summary>
        /// Update the logged on user, by adding the User to follow.
        /// </summary>
        /// <param name="me">the logged on user</param>
        /// <param name="studentToFollow">the user to follow</param>
        /// <remarks>
        /// Calls the methods of the base repository to update and persist the changes.
        /// </remarks>
        private void UpdateUser(User me, User userToFollow)
        {
            me.Following.Add(userToFollow);
            base.Update(me);
            
            base.SaveChanges();
        }

        /// <summary>
        /// Update the logged on user, by removing the User to Unfollow
        /// </summary>
        /// <param name="me"></param>
        /// <param name="userToUnFollow"></param>
        private void RemoveUser(User me, User userToUnFollow)
        {
            me.Following.Remove(userToUnFollow);
            base.Update(me);
            base.SaveChanges();
        }


    }
}
