using System.Linq;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess.DatabaseSetup;
using MOOCollab.WebUI.Controllers;
using MOOCollab.WebUI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Moq;

namespace MOOCollab.UnitTests.ControllerTests

{
    [TestClass]
    public class CourseAdminControllerTests
    {
        [TestMethod]
        public void index_returns_correct_data()
        {
            //arrange
            var repo = new Mock<ICourseRepository>();
            repo.Setup(r => r.GetCoursesForInstructor("Default"))
                .Returns(FakeContext.Courses.Where(c => c.Owner.UserName == "JPaterson"));

            var testRepo = repo.Object;       

            //act 

            var viewDataProduced = (CourseAdminViewModel)new CourseAdminController(testRepo).Index().Model;            

            //assert

            Assert.IsNotNull(viewDataProduced.Courses);

            Assert.IsNotNull(viewDataProduced.CourseMessages);

            Assert.IsNotNull(viewDataProduced.Following);

            Assert.IsNotNull(viewDataProduced.UserMessages);

        }

        [TestMethod]
        public void create_returns_correct_data()
        {
            //arrange
            var repo = new Mock<ICourseRepository>();
            repo.Setup(r => r.CourseAndInstructorByCourseId(1))
                .Returns(FakeContext.Courses.FirstOrDefault(c => c.Id == 1));

            var testRepo = repo.Object;

            //act 

            var viewResult = (ViewResult) new CourseAdminController(testRepo).Create(1);

            var model = (CourseInstructorViewModel)viewResult.Model;

            //assert

            Assert.IsNotNull(model.Instructor);

            Assert.IsNotNull(model.Course);

            Assert.IsNotNull(model.GroupSummaries);


        }

        [TestMethod]
        public void edit_returns_correct_data()
        {
            //arrange
            var repo = new Mock<ICourseRepository>();
            repo.Setup(r => r.CourseAndInstructorByCourseId(1))
                .Returns(FakeContext.Courses.First());

            var testRepo = repo.Object;
            
            //act 

            var viewResult = (ViewResult)new CourseAdminController(testRepo).Edit(1);

            var model = (CourseInstructorViewModel)viewResult.Model;

            //assert

            Assert.IsNotNull(model.Instructor);

            Assert.IsNotNull(model.Course);

            Assert.IsNotNull(model.GroupSummaries);


        }

        [TestMethod]
        public void details_returns_correct_data()
        {
            //arrange
            var repo = new Mock<ICourseRepository>();
            repo.Setup(r => r.CourseAndInstructorByCourseId(1))
                .Returns(FakeContext.Courses.FirstOrDefault());

            var testRepo = repo.Object;

            //act 

            var viewResult = new CourseAdminController(testRepo).Details(1);

            var model = (CourseInstructorViewModel)viewResult.Model;

            //assert

            Assert.IsNotNull(model.Instructor);

            Assert.IsNotNull(model.Course);

            Assert.IsNotNull(model.GroupSummaries);

            Assert.IsNotNull(model.MessageInfos);
        }



        [TestMethod]
        public void delete_returns_correct_data()
        {
            //arrange
            var repo = new Mock<ICourseRepository>();
            repo.Setup(r => r.CourseAndInstructorByCourseId(1))
                .Returns(FakeContext.Courses.FirstOrDefault());

            var testRepo = repo.Object;

            //act 

            var viewResult = (ViewResult)new CourseAdminController(testRepo).Delete(1);

            var model = (CourseInstructorViewModel)viewResult.Model;

            //assert

            Assert.IsNotNull(model.Instructor);

            Assert.IsNotNull(model.Course);

            Assert.IsNotNull(model.GroupSummaries);


        }

    }
}