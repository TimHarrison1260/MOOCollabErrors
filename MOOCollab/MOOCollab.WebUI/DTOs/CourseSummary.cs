using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOOCollab.WebUI.DTOs
{
    public class CourseSummary
    {
        public int Id { get; set; }
        public string Lecturer { get; set; }
        public string Title { get; set; }
        public int NoOfStudents { get; set; }
        public int NoOfGroups { get; set; }
        public bool Status { get; set; }

        public CourseSummary()
        {
            
        }
    }
}