using System.Linq;
using MOOCollab.Domain;

namespace MOOCollab.Contracts.RepositoryContracts
{
    public interface ICourseRepository:IRepository<Course>
    {
        IQueryable<Course> GetCoursesForInstructor(string userName);
        Course CourseAndInstructorByCourseId(int id);
        //IQueryable<Course> GetCoursesStudentCanJoin(int id);

       
    }
}