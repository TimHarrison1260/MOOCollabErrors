using System.Linq;
using MOOCollab.DataAccess.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace MOOCollab.UnitTests.DbEntityIntegrationTests
{
    [TestClass]
    public class CourseEntity
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
            var courses = _db.Courses
                             .Include(c => c.Groups)
                             .Include(c => c.Achievments)
                             .Include(c => c.Students)
                             .Include(c => c.Owner)
                             .Include(c => c.CourseMessages);

            var testCourse = courses.First();

            Assert.IsNotNull(testCourse.Groups);
            Assert.IsNotNull(testCourse.Achievments);
            Assert.IsNotNull(testCourse.Students);
            Assert.IsNotNull(testCourse.Owner);
            Assert.IsNotNull(testCourse.CourseMessages);

        }

        [TestMethod]
        public void details_are_not_null()
        {
            var course = _db.Courses.Find(1);

            Assert.IsNotNull(course.Title);
            Assert.IsNotNull(course.Resume);
            Assert.IsNotNull(course.Status);
        }

        [ClassCleanup]
        public static void Dispose()
        {
            _db.Dispose();
        } 
    }
}