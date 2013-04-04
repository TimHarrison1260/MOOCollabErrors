using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MOOCollab.Domain
{
    public class Achievment
    {
        public int Id { get; set; }
        public DateTime DateAwarded { get; set; }
        public AwardType AwardType { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }

        public Achievment()
        {
            DateAwarded = DateTime.Today;
        }
    }
}
