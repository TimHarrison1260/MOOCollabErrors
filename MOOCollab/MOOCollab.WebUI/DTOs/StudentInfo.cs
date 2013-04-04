using System.Collections.Generic;
using System.Linq;
using MOOCollab.Domain;

namespace MOOCollab.WebUI.DTOs
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int CourseId { get; set; }
        public List<AchievmentSummary> AchievmentSummaries { get; set; }


        public StudentInfo(Student student,int courseId)
        {
            Id = student.Id;
            Name = student.UserName;
            ImagePath = student.ImagePath;
            CourseId = courseId;
            AchievmentSummaries = student.Achievments
                .Select(s=>new AchievmentSummary(s)).ToList();
        }
    }
}