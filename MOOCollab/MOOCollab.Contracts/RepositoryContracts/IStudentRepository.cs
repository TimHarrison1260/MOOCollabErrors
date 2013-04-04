using MOOCollab.Domain;

namespace MOOCollab.Contracts.RepositoryContracts
{
    public interface IStudentRepository :IRepository<Student>
    {
        Student GetStudentandCourseInfoForAward(int studentId, int courseId);
    }
}
