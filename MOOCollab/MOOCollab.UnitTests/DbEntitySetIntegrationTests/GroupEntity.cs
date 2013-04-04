using System.Linq;
using MOOCollab.DataAccess.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace MOOCollab.UnitTests.DbEntityIntegrationTests
{
    [TestClass]
    public class GroupEntity
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
            var groups = _db.Groups
                            .Include(g => g.Course)
                            .Include(g => g.Members)
                            .Include(g => g.Owner)
                            .Include(g=>g.GroupMessages);

            var testGroup = groups.First();

            Assert.IsNotNull(testGroup.Course);
            Assert.IsNotNull(testGroup.Members);
            Assert.IsNotNull(testGroup.Owner);
            Assert.IsNotNull(testGroup.GroupMessages);
        }

        [TestMethod]
        public void details_are_not_null()
        {
            var testGroup = _db.Groups.Find(1);

            Assert.IsNotNull(testGroup.Title);

            Assert.IsNotNull(testGroup.Status);

            Assert.IsNotNull(testGroup.GroupSize);

            Assert.IsNotNull(testGroup.Owner);

        }

        [ClassCleanup]
        public static void Dispose()
        {
            _db.Dispose();
        } 
    }
}