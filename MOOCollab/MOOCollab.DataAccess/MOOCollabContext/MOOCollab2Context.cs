using System.Data.Entity;
using MOOCollab.Contracts;
using MOOCollab.DataAccess.DatabaseSetup;
using MOOCollab.Domain;
//using WebMatrix.WebData;

namespace MOOCollab.DataAccess.MOOCollabContext
{
    /// <summary>
    /// Base Context class for the domain.  Inherits from DbContext and implements the 
    /// IMOOCollabContext in order to allow a seperate database to work of the same seed data
    /// </summary>
    public class MOOCollab2Context : DbContext, IUow
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Instructor> Instructors { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Group> Groups { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<UserMessage> UserMessages { get; set; }
        public IDbSet<GroupMessage> GroupMessages { get; set; }
        public IDbSet<CourseMessage> CourseMessages { get; set; }
        public IDbSet<Achievment> Achievments { get; set; }


        public MOOCollab2Context()
            : base("name=MOOCollab2Context")//connect to production database
        {
            //Database.SetInitializer(new MOOCollab2Config());
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DataBaseMappings.ApplyMappings(modelBuilder);
        }


    }
}
