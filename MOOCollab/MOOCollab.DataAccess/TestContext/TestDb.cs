using System.Data.Entity;
using MOOCollab.Contracts;
using MOOCollab.DataAccess.DatabaseSetup;
using MOOCollab.Domain;

namespace MOOCollab.DataAccess.TestContext
{
    /// <summary>
    /// Test Context.  Implements the IMOOCollabContext contract
    /// ensuring that the test Db has the same entities defined and can work of the same seed data
    /// </summary>
    public class TestDb : DbContext, IUow
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Instructor> Instructors { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Group> Groups { get; set; }
        public IDbSet<UserMessage> UserMessages { get; set; }
        public IDbSet<GroupMessage> GroupMessages { get; set; }
        public IDbSet<CourseMessage> CourseMessages { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<Achievment> Achievments { get; set; }

        public TestDb()
            : base("name=TestDb")//Connect to test db context
        {
            Database.SetInitializer(new TestDbConfig());
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DataBaseMappings.ApplyMappings(modelBuilder);
        }
    }
}
