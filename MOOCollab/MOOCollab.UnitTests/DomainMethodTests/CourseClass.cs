using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MOOCollab.UnitTests.DomainMethodTests
{
    [TestClass]
    public class CourseClass
    {
        [TestMethod]
        public void course_class_delete_closes_groups()
        {
            //arrange
            var course = FakeContext.Courses.FirstOrDefault(c=>c.Groups.Count > 0);

            
            //act
            if(course!=null)
            course.CloseCourse();

            var result = course.Groups.All(g => g.Status == false);
            //assert

            Assert.IsTrue(result);

        }

    }
}