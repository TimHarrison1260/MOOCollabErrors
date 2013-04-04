using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOOCollab.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Student Owner { get; set; }
        public int OwnerId { get; set; }
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
        public int GroupSize { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Student> Members { get; set; }
        public virtual ICollection<GroupMessage> GroupMessages { get; set; }

        public bool IsAvailableToJoin()
        {
            //test
            return true;//todo
        }

        public bool IsOpen()
        {
            return true;//todo
        }

    }
}
