using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOOCollab.Domain
{
    //[Table("UserProfile")]
    public class User
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<User> Followers { get; set; }//Users that are following this user
        public virtual ICollection<User> Following { get; set; }//Users that this user follows
        public virtual ICollection<UserMessage> MessagesSent { get; set; }


        #region IsFollower Overloads
        /// <summary>
        /// Determines if the Other User is a Follower of This User (Me).
        /// </summary>
        /// <param name="OtherUserId">Id of the other User</param>
        /// <returns>Returne TRUE if the other user is following this user, otherwise returns FALSE</returns>
        public bool IsFollower(int OtherUserId)
        {
            var result = (this.Followers.FirstOrDefault(u => u.Id == OtherUserId) != null) ? true : false;
            return result;
        }

        /// <summary>
        /// Determines if the Other User is a Follower of this User (Me)
        /// </summary>
        /// <param name="OtherUser">The other user object</param>
        /// <returns>Returne TRUE if the other user is following this user, otherwise returns FALSE</returns>
        public bool IsFollower(User OtherUser)
        {
            return this.IsFollower(OtherUser.UserName);
        }

        /// <summary>
        /// Determines if the Other User is a follower of this User (Me)
        /// </summary>
        /// <param name="otherUserName">The userName of the other user</param>
        /// <returns>Returne TRUE if the other user is following this user, otherwise returns FALSE</returns>
        public bool IsFollower(string otherUserName)
        {
            var result = (this.Followers.FirstOrDefault(u => u.UserName == otherUserName) != null) ? true : false;
            return result;
        }

        #endregion

        #region IsFollowing Overloads
        /// <summary>
        /// Determines if the this User (Me) is Following the Other User
        /// </summary>
        /// <param name="OtherUserId">Id of the Other User</param>
        /// <returns>Returns TRUE if this User is Following the Other User, otherwise returns FALSE</returns>
        public bool IsFollowing(int OtherUserId)
        {
            var result = (this.Following.FirstOrDefault(u => u.Id == OtherUserId) != null) ? true : false;
            return result;
        }

        /// <summary>
        /// Determines if the this User (Me) is Following the Other User
        /// </summary>
        /// <param name="OtherUser">The Other User object</param>
        /// <returns>Returns TRUE if this User is Following the Other User, otherwise returns FALSE</returns>
        public bool IsFollowing(User OtherUser)
        {
            return this.IsFollowing(OtherUser.UserName);
        }

        /// <summary>
        /// Determines if the this User (Me) is Following the Other User
        /// </summary>
        /// <param name="otherUserName">The UserName of the other user</param>
        /// <returns>Returns TRUE if this User is Following the Other User, otherwise returns FALSE</returns>
        public bool IsFollowing(string otherUserName)
        {
            //            var result = this.Following.FirstOrDefault(u => u.UserName.ToLower() == otherUserName.ToLower());
            var result = (this.Following.FirstOrDefault(u => u.UserName == otherUserName) != null) ? true : false;
            return result;
        }

        #endregion


        #region Type methods

        /// <summary>
        /// Determines if the derived type is "Student"
        /// </summary>
        /// <returns>Returns True if this type is Student, otherwise false.</returns>
        public bool IsStudent()
        {
            return (this.GetType().Name.StartsWith(typeof(Student).Name));
        }

        /// <summary>
        /// Determines if the derived type is "Instructor")
        /// </summary>
        /// <returns>Return True if this type is Instructor, otherwise false</returns>
        public bool IsInstructor()
        {
            return (this.GetType().Name.StartsWith(typeof(Instructor).Name));
        }

        #endregion



    }
}