using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MOOCollab.Domain
{
    public class Instructor : User
    {
        public virtual ICollection<Course> Courses { get; set; }//discuss
    }
}
