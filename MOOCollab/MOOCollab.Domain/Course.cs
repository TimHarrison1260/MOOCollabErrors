using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MOOCollab.Domain
{
    public class Course 
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(2000)]
        public string Resume { get; set; }
        public virtual Instructor Owner { get; set; }
        public int OwnerId { get; set; }
        public bool Status { get;  set; }    //todo investigate making this private
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Achievment> Achievments { get; set; }
        public virtual ICollection<CourseMessage> CourseMessages { get; set; }

        public Course()
        {
            Status = true;
        }

        public bool IsAvailableToJoin()
        {
            return true;//todo
        }

        public bool IsMember()
        {
            return true;//todo
        }

        public void CloseCourse()
        {   //close groups
            foreach (var group in Groups)
            {
                group.Status = false;
            }

            Status = false;
        }

        public void AwardAchievment(Student student, Achievment achievment) { } 

    }

  
}
