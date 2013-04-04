using System.Linq;
using MOOCollab.DataAccess.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace MOOCollab.UnitTests.DbEntitySetIntegrationTests
{
    [TestClass]
    public class CourseMessageEntity
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
          var messages =   _db.CourseMessages
               .Include(cm => cm.Course)
               .Include(cm => cm.Sender);

            var testMessage = messages.First();

            Assert.IsNotNull(testMessage.Course);
            Assert.IsNotNull(testMessage.Sender);
        }

        [TestMethod]
        public void details_are_not_null()
        {
            var messages = _db.CourseMessages
               .Include(cm => cm.Course)
               .Include(cm => cm.Sender);

            var testMessage = messages.First();

            Assert.IsNotNull(testMessage.Course);
            Assert.IsNotNull(testMessage.Sender);
            Assert.IsNotNull(testMessage.Content);
            Assert.IsNotNull(testMessage.DateSent);
            Assert.IsNotNull(testMessage.Title);
            
        }

        [ClassCleanup]
        public static void Dispose()
        {
            _db.Dispose();
        } 
    }
}