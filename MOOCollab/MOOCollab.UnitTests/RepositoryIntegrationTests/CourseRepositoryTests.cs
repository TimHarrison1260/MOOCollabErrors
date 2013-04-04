using System.Linq;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.DataAccess.TestContext;
using MOOCollab.DataAccess.Repositories;
using MOOCollab.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace MOOCollab.UnitTests.RepositoryIntegrationTests
{
    [TestClass]
    public class CourseRepositoryTest
    {
        [TestMethod]
        public void delete_applies_soft_delete()
        {
            //var repo = new CourseRepository(new MOOCollab2UOW());
            var repo = new CourseRepository(new TestDb());

            var testCourse = new Course { Id = 1, Status = true };


            //act
            repo.Delete(testCourse);

            var changedCourse = repo.CourseAndInstructorByCourseId(1);//get changed course
            //assert
            Assert.IsFalse(changedCourse.Status);
            Assert.IsNull(changedCourse.Groups.FirstOrDefault(g => g.Status == true));

        }

        [TestMethod]
        public void created_course_is_assigned_to_correct_instructor()
        {
            //using (var Uow = new MOOCollab2UOW())
            using (var Uow = new TestDb())
            {
                //Arrange
                var courseRepo = new CourseRepository(Uow);
                var instructorRepo = new InstructorRepository(Uow);
                var testInstructor = instructorRepo.Find(1);

                courseRepo.Create(new Course
                {
                    OwnerId = 1,//course to instructor with Id of one
                    Title = "Test",
                    Resume = "Argh",//test text
                    Status = true
                });
                courseRepo.SaveChanges();
            }

            //using (var Uow = new MOOCollab2UOW())
            using (var Uow = new TestDb())
            {
                //Arrange
                var instructorRepo = new InstructorRepository(Uow);


                //Act
                var instructor = instructorRepo.FindAll()
                                .Include(i => i.Courses)
                                .FirstOrDefault(i => i.Id == 1);
                //assert  //Check if instructor has the new course
                Assert.IsNotNull(instructor.Courses.FirstOrDefault(c => c.Resume == "Argh"));
            }

        }

        [TestMethod]
        public void Course_And_Instructor_By_Id_data_verified()
        {
            Course testcourse;
            //using (var Uow = new MOOCollab2UOW())
            using (var Uow = new TestDb())
            {
                //Arrange
                var courseRepo = new CourseRepository(Uow);
                testcourse = courseRepo.CourseAndInstructorByCourseId(1);


            }
            Assert.IsNotNull(testcourse.OwnerId);
        }

    }
}