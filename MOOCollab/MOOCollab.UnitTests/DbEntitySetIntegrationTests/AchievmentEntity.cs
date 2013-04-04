using System.Linq;
using MOOCollab.DataAccess.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace MOOCollab.UnitTests.DbEntityIntegrationTests
{
    [TestClass]
    public class AchievmentEntity
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
            var achievments = _db.Achievments
                                 .Include(a => a.Student)
                                 .Include(a=>a.Course);

            var testAchievment = achievments.First(); 

            Assert.IsNotNull(testAchievment.Student);
            Assert.IsNotNull(testAchievment.Student);
        }

        [TestMethod]
        public void details_are_not_null()
        {
            var achievment = _db.Achievments.Find(2);

            Assert.IsNotNull(achievment.AwardType);

            //TODO Assert.IsNotNull(achievment);

            Assert.IsNotNull(achievment.DateAwarded);

            Assert.IsNotNull(achievment.Description);

        }

        [ClassCleanup]
        public static void Dispose()
        {
            _db.Dispose();
        } 
    }
}