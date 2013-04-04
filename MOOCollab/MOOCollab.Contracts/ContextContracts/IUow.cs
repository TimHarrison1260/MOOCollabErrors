using System;
using System.Data.Entity;
using MOOCollab.Domain;

namespace MOOCollab.Contracts
{
    /// <summary>
    /// Interface providing behavior required to implement the
    /// unit of work pattern
    /// </summary>
    /// <typeparam name="T">
    /// Type must implement IDisposable and be an implementation
    /// of entityframework's dbContext
    /// </typeparam>
    //public interface IUow<T>:IDisposable where T :DbContext
    //public interface IUow<T>:IDisposable where T : IMOOCollabContext
    public interface IUow
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Student> Students { get; set; }
        IDbSet<Instructor> Instructors { get; set; }
        IDbSet<Course> Courses { get; set; }
        IDbSet<Group> Groups { get; set; }
        IDbSet<Message> Messages { get; set; }
        IDbSet<UserMessage> UserMessages { get; set; }
        IDbSet<GroupMessage> GroupMessages { get; set; }
        IDbSet<CourseMessage> CourseMessages { get; set; }
        IDbSet<Achievment> Achievments { get; set; }

        int SaveChanges();
    }
}
