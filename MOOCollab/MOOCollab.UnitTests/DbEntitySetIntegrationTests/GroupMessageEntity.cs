using System.Linq;
using MOOCollab.DataAccess.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace MOOCollab.UnitTests.DbEntitySetIntegrationTests
{
    [TestClass]
    public class GroupMessageEntity
    {
        private static TestDb _db;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _db = new TestDb();
        }

        [TestMethod]
        public void details_are_not_null()
        {
            var testMessage = _db.GroupMessages
                .Include(gm=>gm.Group)
                .Include(gm=>gm.Sender).First();
            
          
            Assert.IsNotNull(testMessage.DateSent);
            Assert.IsNotNull(testMessage.Title);
            Assert.IsNotNull(testMessage.Content);
            Assert.IsNotNull(testMessage.Id);
            Assert.IsNotNull(testMessage.Sender);
            Assert.IsNotNull(testMessage.Group);
            
        }

        [ClassCleanup]
        public static void Dispose()
        {
            _db.Dispose();
        } 
    }
}