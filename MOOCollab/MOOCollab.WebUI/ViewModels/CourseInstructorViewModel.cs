using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOOCollab.Domain;
using MOOCollab.WebUI.DTOs;
using WebGrease.Css.Extensions;

namespace MOOCollab.WebUI.ViewModels
{
    public class CourseInstructorViewModel
    {
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
        public List<GroupSummary> GroupSummaries { get; set; }
        public List<MessageInfo> MessageInfos { get; set; }
        public List<StudentInfo> StudentInfos { get; set; }


        /// <summary>
        /// Constructor for Create action of a course
        /// </summary>
        /// <param name="id">Id of the instructor</param>
        public CourseInstructorViewModel(int id)
        {
            Instructor = new Instructor {Id = id};
            Course = new Course {
                OwnerId = Instructor.Id,
                Status = true,
                
            };
            GroupSummaries = new List<GroupSummary>();
            MessageInfos = new List<MessageInfo>();
        }

        public CourseInstructorViewModel()
        {         
        }
        /// <summary>
        /// Convert retrieved course for editing
        /// </summary>
        /// <param name="course">Course with owner</param>
        public CourseInstructorViewModel(Course course)
        {
            Course = course;
            Instructor = course.Owner;

            GroupSummaries =  course.Groups.Select(g => new GroupSummary
               (g)).ToList();

            MessageInfos = course.CourseMessages
                .Select(m => new MessageInfo(m)).ToList();

            StudentInfos = course.Students
                .Select(s=>new StudentInfo(s,courseId:course.Id))
                .ToList();

        }
       
    }
}