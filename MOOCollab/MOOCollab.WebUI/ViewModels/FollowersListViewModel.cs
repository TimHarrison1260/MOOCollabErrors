using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MOOCollab.WebUI.ViewModels
{
    public class FollowersLIstViewModel
    {
        public string MyName { get; set; }
        public IList<Member> Members { get; set; }
    }

    public class Member
    {
        public int Id { get; set; }

        [DisplayName("Colleagues Name")]
        public string Name { get; set; }

        [DisplayName("Instructor or Student")]
        public string Type { get; set; }

        [DisplayName("Am I Following")]
        public bool IsFollowing { get; set; }
    }
}