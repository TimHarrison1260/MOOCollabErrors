using System.Linq;
using MOOCollab.DataAccess.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace MOOCollab.UnitTests.DbEntityIntegrationTests
{
    [TestClass]
    public class StudentEntity
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
          
           
            var students = _db.Students
                              .Include(s => s.CoursesTaken.Select(c=>c.Owner))
                              .Include(s => s.Groups)
                              .Include(s => s.Achievments)
                              .Include(s => s.GroupsOwned)
                              .Include(s=>s.MessagesSent)
                              .ToList();

            var  testStudent = students[0];

            Assert.IsNotNull(testStudent.Achievments);
            Assert.IsNotNull(testStudent.CoursesTaken);
            Assert.IsNotNull(testStudent.CoursesTaken.Select(c=>c.Owner));
            Assert.IsNotNull(testStudent.GroupsOwned);
            Assert.IsNotNull(testStudent.Groups);
            Assert.IsNotNull(testStudent.MessagesSent);
        }

        [TestMethod]
        public void details_are_not_null()
        {
            var testStudent = _db.Students.First();

            Assert.IsNotNull(testStudent.UserName);
            Assert.IsNotNull(testStudent.Id);
        }

        [TestMethod]
        public void student_is_following_jim()
        {
            //Get jim
            var jim = _db.Instructors
               .FirstOrDefault(i => i.UserName == "JPaterson");
            //get first student
            var student = _db.Students
                             .Include(s => s.Following)
                             .First();
            //get list of people the student is following
            var peopleStudentFollows = student.Following;
            //Check the Id of person in the students following list and Jim's id
            Assert.AreEqual(jim.Id, peopleStudentFollows
                .FirstOrDefault(p=>p.UserName == "JPaterson").Id);
            //Check they are the same object
            Assert.AreSame(jim, peopleStudentFollows
                .FirstOrDefault(p => p.UserName == "JPaterson"));

        }

        [TestMethod]
        public void andrew_can_follow_brian()
        {

            var brian = _db.Instructors.FirstOrDefault(i => i.UserName == "BMacDonald");

            var andrew = _db.Students.Include(s => s.Following).FirstOrDefault(s => s.UserName == "Andrew");

            var followed = andrew.Following.FirstOrDefault(f => f.UserName == "BMacDonald");

            Assert.AreSame(followed, brian);
        }


        [TestMethod]
        public void robert_stalks_narelle()
        {
            //have robert follow narelle
            using (var db = new TestDb())
            {
                var rob = db.Students.Include(s => s.Following).FirstOrDefault(s => s.UserName == "Robert");

                var narelle = db.Students.Include(s=>s.Following).FirstOrDefault(s => s.UserName == "Narelle");

                rob.Following.Add(narelle);

                db.SaveChanges();
            }       
               
            //Get Narelle plus followers
           var narelle2 = _db.Students.Include(s=>s.Followers).FirstOrDefault(s => s.UserName == "Narelle");

           Assert.IsNotNull(narelle2.Followers.FirstOrDefault(f=>f.UserName=="Robert"));
           
        }

        [ClassCleanup]
        public static void Dispose()
        {
            _db.Dispose();
        }
    }
}
