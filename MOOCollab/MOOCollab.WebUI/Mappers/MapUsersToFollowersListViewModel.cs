using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

using MOOCollab.Domain;
using MOOCollab.WebUI.ViewModels;

namespace MOOCollab.WebUI.Mappers
{
    public static class MapUsersToFollowersListViewModelAsync
    {
        public static FollowersLIstViewModel Map(int CourseId, ICollection<User> Users, string myUserName)
        {
            var viewModel = new FollowersLIstViewModel()
            {
                MyName = myUserName,
                Members = new List<Member>(),
            };
            foreach (Domain.User u in Users)
            {
                var m = new Member()
                {
                    Id = u.Id,
                    Name = u.UserName,
                    Type = (u.IsStudent() ? "Student" : "Instructor"),
                    IsFollowing = u.IsFollower(myUserName)
                };
                viewModel.Members.Add(m);
            }
            return viewModel;
        }
    }
}