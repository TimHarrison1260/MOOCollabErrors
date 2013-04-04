using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOOCollab.DataAccess.DatabaseSetup;
namespace MOOCollab.UnitTests
{
    [TestClass]
    public class ContextTest
    {
        [TestMethod]
        public void ContestTest()
        {
            var users = FakeContext.Users;
            var students = FakeContext.Students;
            var instructors = FakeContext.Instructors;
            var achievments = FakeContext.Achievments;
            var courses = FakeContext.Courses;
            var groups = FakeContext.Groups;
            var userMessages = FakeContext.UserMessages;
            var courseMessages = FakeContext.CourseMessages;
            var groupmessages = FakeContext.GroupMessages;

            var andrew = students.AsEnumerable().FirstOrDefault(s => s.UserName == "Andrew");
            var tim = students.AsEnumerable().FirstOrDefault(s => s.UserName == "Tim");

            

        }
    }
}