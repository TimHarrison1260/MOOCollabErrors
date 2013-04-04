using System.Linq;
using MOOCollab.Contracts;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.Domain;
using System.Data.Entity;

namespace MOOCollab.DataAccess.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        /// <summary>
        /// Calls to base Repository in order to ensure all repositories use 
        /// the correct unit of work.
        /// DbContext is reachable through the Context property.
        /// 
        /// DbSet is reachable through the Set property.
        /// </summary>
        /// <param name="uow">
        /// Implemetation of IUow of T injected using ninject
        /// </param>
        public StudentRepository(IUow uow)
            : base(uow)
        {
        }

        public Student GetStudentandCourseInfoForAward(int studentId, int courseId)
        {
           return Set.Include(c => c.CoursesTaken)
                .FirstOrDefault(s=>s.Id == studentId);
        }
    }
}