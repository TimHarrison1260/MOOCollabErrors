using System.Data;
using System.Linq;
using MOOCollab.Contracts;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.Domain;
using System.Data.Entity;

namespace MOOCollab.DataAccess.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        /// <summary>
        /// Calls to base Repository in order to ensure all repositories use 
        /// the correct unit of work.
        /// DbContext is reachable through the Uow property.
        /// 
        /// DbSet is reachable through the Set property.
        /// </summary>
        /// <param name="uow">
        /// Implemetation of IUow of T injected using ninject
        /// </param>
        public CourseRepository(IUow uow)
            : base(uow)
        {
        }

        /// <summary>
        /// Get Courses for the supplied instructor id with all information
        /// required to populate the instructor admin viewmodel 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public IQueryable<Course> GetCoursesForInstructor(string userName)
        {
            var courses = Set.Include(c => c.Students)
                               .Include(c => c.CourseMessages)
                               .Include(c => c.Achievments)
                               .Include(c => c.Owner)
                               .Where(i => i.Owner.UserName == userName);
            return courses;
        }
        /// <summary>
        /// Get Course by id with info that an
        /// instructor relies on for course administration
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Course CourseAndInstructorByCourseId(int id)
        {
            return Set.Include(c => c.Owner)
                .Include(c => c.Groups)
                .Include(c => c.CourseMessages)
                .Include(c => c.Students.Select(s=>s.Achievments.Select(a=>a.Course)))
                .FirstOrDefault(c => c.Id == id);
        }

      

        public override void Update(Course obj)
        {

            var current = Set.Local.FirstOrDefault(c => c.Id == obj.Id);
            if (current != null)
            {
                Context.Entry(current).CurrentValues.SetValues(obj);
            }
            else
            {
                base.Update(obj);
            }


        }

        /// <summary>
        /// Apply soft delete to course. Also closes groups.
        /// </summary>
        /// <param name="id">Id of course to delete</param>
        public override void Delete(int id)
        {
            var courseToClose = Set.Include(c => c.Owner)
                                   .Include(c => c.Groups)
                                   .FirstOrDefault(c => c.Id == id);

            if (courseToClose != null)
            {
                courseToClose.CloseCourse();//Close associated groups.

                Context.Entry(courseToClose).State = EntityState.Modified;
            }
        }

        public override void Delete(Course obj)
        {
            var courseToClose = Set.Include(c => c.Owner)
                                    .Include(c => c.Groups)
                                    .FirstOrDefault(c => c.Id == obj.Id);

            if (courseToClose != null)
            {
                courseToClose.CloseCourse();//Close associated groups.

                Context.Entry(courseToClose).State = EntityState.Modified;
            }
        }
    }
}