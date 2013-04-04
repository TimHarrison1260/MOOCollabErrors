using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOOCollab.Domain
{
    public class Student : User
    {
        public virtual ICollection<Course> CoursesTaken { get; set; }

        public virtual ICollection<Achievment> Achievments { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<Group> GroupsOwned { get; set; }

        public bool IsMemberOfCourse(int id)
        {
            return true;//Todo
        }
    }
}
