using System.Data.Entity;
using System.Linq;
using MOOCollab.DataAccess.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MOOCollab.UnitTests.DbEntitySetIntegrationTests
{
    [TestClass]
    public class UserMessageEntity
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
            var testMessage = _db.UserMessages

              .Include(um => um.Sender)
              .FirstOrDefault(u => u.SenderId == 1);

            Assert.IsNotNull(testMessage.Sender);
        }

        [TestMethod]
        public void details_are_not_null()
        {
            //Act
            //get first message of user 1
            var testMessage = _db.UserMessages
                
                .Include(um => um.Sender)
                .FirstOrDefault();

          

            Assert.IsNotNull(testMessage.DateSent);
            Assert.IsNotNull(testMessage.Title);
            Assert.IsNotNull(testMessage.Content);
            Assert.IsNotNull(testMessage.Id);
            Assert.IsNotNull(testMessage.Sender);
           
        }

        [TestMethod]
        public void first_message_of_user1_is_the_same_from_user_and_message_dbSet()
        {

            //Act
            //get first message of user 1
            var testMessage = _db.UserMessages

                .Include(um => um.Sender)
                .FirstOrDefault(u => u.SenderId == 1);

            //get user 1
            var testUser = _db.Users
                              .Include(u => u.MessagesSent)
                              .FirstOrDefault(u => u.Id == 1);

            //get message of user 1 where message Id == testmessage
            var userMessage = testUser.MessagesSent
                                      .FirstOrDefault(m => m.Id == testMessage.Id);
            //Assert
            Assert.AreEqual(testMessage, userMessage);

          
        }

        [ClassCleanup]
        public static void Dispose()
        {
            _db.Dispose();
        } 
    }
}