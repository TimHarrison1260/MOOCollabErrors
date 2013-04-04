using System.Linq;
using MOOCollab.DataAccess.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace MOOCollab.UnitTests.DbEntitySetIntegrationTests
{
    [TestClass]
    public class InstructorEntity
    {
        private static TestDb _db;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _db = new TestDb();
        }

        [TestMethod]
        public void navigation_properties_are_navigable()
        {
            var instructors = _db.Instructors
                                 .Include(i => i.Courses.Select(c => c.Students))
                                 .Include(i => i.Courses.Select(c => c.Groups))
                                 .Include(i=>i.MessagesSent)
                                 .ToList();

            var testInstructor = instructors[0];

            Assert.IsNotNull(testInstructor.Courses);
            Assert.IsNotNull(testInstructor.MessagesSent);
            
        }

        [TestMethod]
        public void details_are_not_null()
        {
            var testInstructor = _db.Instructors.Find(2);
            Assert.IsNotNull(testInstructor.UserName);
            Assert.IsNotNull(testInstructor.Id);
        }

        [TestMethod]
        public void jim_is_followed_by_all_students()
        {
            //Count all registered students
            var noOfStudents = _db.Students.Count();
            //Get Jim
            var jim = _db.Instructors
                         .Include(i => i.Followers)
                         .FirstOrDefault(j=>j.UserName =="JPaterson");

            //Compare the number of students following Jim to the no in the Db.
            Assert.AreEqual(jim.Followers.Count, noOfStudents);
        }

        [ClassCleanup]
        public static void Dispose()
        {
            _db.Dispose();
        } 
    }
}