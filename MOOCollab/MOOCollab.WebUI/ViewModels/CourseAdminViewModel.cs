using System.Collections.Generic;
using System.Linq;
using MOOCollab.Domain;


namespace MOOCollab.WebUI.ViewModels
{
    public class CourseAdminViewModel
    {
        public List<Course> Courses { get; set; }//courses instructor takes/has taken
        public List<UserMessage> UserMessages { get; set; }//messages of people that instructor is following
        public List<User> Following { get; set; }//users instructor is following
        public List<CourseMessage> CourseMessages { get; set; }//messages relating to course
        public int InstructorId { get; set; }
        public UserMessage UserMessage { get; set; }

        /// <summary>
        /// Presents instructor related info to the instructor
        /// admin view. 
        /// </summary>
        /// <param name="courses">
        /// Retrieved graph of course related data
        /// </param>
        public CourseAdminViewModel(List<Course> courses )//prevent n+1
        {
            
            Courses = courses;
            CourseMessages = courses.SelectMany(c => c.CourseMessages).ToList();

            var course = courses.FirstOrDefault();
            if (course != null) Following = course.Owner.Following.ToList();
            //get messages of people that instructor is following

            var ownerinfo = courses.FirstOrDefault();//get the first course
            if (ownerinfo != null)
            {
                UserMessages = ownerinfo
                                      .Owner//get the current instructor info
                                      .Following//From the people he/she follows
                                      .SelectMany(f => f.MessagesSent)//get all the messages
                                      .ToList();

                InstructorId = ownerinfo.OwnerId;

            }
        }

        public CourseAdminViewModel()
        {
            
        }
    }
}