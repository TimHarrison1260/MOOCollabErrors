using System;
using System.Collections.Generic;
using System.Linq;
using MOOCollab.Domain;

namespace MOOCollab.WebUI.ViewModels
{
    public class AchievmentViewModel
    {
        public DateTime DateAwarded { get; set; }
        public AwardType AwardType { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }

        public AchievmentViewModel()
        {
            
        }

        public AchievmentViewModel(Student student, int courseId)
        {
            Course = student.CoursesTaken.FirstOrDefault(c=>c.Id == courseId);
            if (Course != null) CourseId = Course.Id;
            DateAwarded = DateTime.Now;
            Student = student;
            StudentId = student.Id;
            
        }
    }
}