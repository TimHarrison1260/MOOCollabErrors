using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.Domain;
using MOOCollab.WebUI.ViewModels;
using MOOCollab.WebUI.Mappers;

namespace MOOCollab.WebUI.Controllers
{
    [Authorize(Roles = "Instructor,Student")]
    [HandleError]
    public class FollowersController : Controller
    {
        //  Private instance of the UserRepository
        private readonly IUserRepository _repository;

        public FollowersController(IUserRepository Repository)
        {
            if (Repository == null)
                throw new ArgumentNullException("Repository", "No valid UserRepository supplied to FollowersController");
            _repository = Repository;
        }

        //
        //  GET: /Followers/
        //      It show show the Students on a specified course
        //
        //  NB! This is only here to allow the followers to be tested separately from the 
        //      rest of the application.  The view is an example of rendering the partial view
        //      directly.
        public ActionResult Index(int? id)
        {
            var me = ControllerContext.HttpContext.User.Identity.Name;
            ViewBag.Message = "Show a List of Members belonging to a Course";
            ViewBag.CourseOrGroupId = (id != null) ? id.ToString() : "1";
            ViewBag.MyId = me;
            return View();
        }

        //
        //  GET: /Followers/List/1
        //      It show show the Students on a specified group
        //
        //  NB! This is only here to allow the followers to be tested separately from the 
        //      rest of the application.  The view is an example of loading the partial view
        //      asynchronously using an Ajax call.
        public ActionResult List(int id)
        {
            var me = ControllerContext.HttpContext.User.Identity.Name;
            ViewBag.Message = "Show a List of Members belonging to a Group";
            ViewBag.CourseOrGroupId = id;
            ViewBag.MyId = me;
            return View();
        }

        //  Loads the partial view _FollowersList with the members of the 
        //  specified CourseId
        public ActionResult CourseFollowersList(int id)
        {
            //  Get me, the logged on user.
            //  TODO:   refactor this to use the HelperMethod, if they're staying in the project
            var me = ControllerContext.HttpContext.User.Identity.Name;
            ViewBag.Title = "Fellow members on this course";

            //  Get the list of users for the Course / Group, call the Repository 
            var users = _repository.GetUsersForCourse(id, me).ToList<Domain.User>();

            //  Map the domain students to the View Model
            var viewModel = Mappers.MapUsersToFollowersListViewModelAsync.Map(id, users, me);

            //  Render the partial view.
            return PartialView("_FollowersList", viewModel);
        }

        //  Loads the partial view _FollowersList with the members of the 
        //  specified GroupId
        public ActionResult GroupFollowersList(int id)
        {
            //  get Me, the logged on user.
            //  TODO:   refactor this to use the HelperMethod, if they're staying in the project
            var me = ControllerContext.HttpContext.User.Identity.Name;
            ViewBag.Title = "Fellow members in this group";

            //  Get the list of users for the Course / Group, call the Repository 
            var users = _repository.GetUsersForGroup(id, me).ToList<Domain.User>();

            //  Map the domain students to the View Model
            var viewModel = Mappers.MapUsersToFollowersListViewModelAsync.Map(id, users, me);

            //  Render the partial view.
            return PartialView("_FollowersList", viewModel);
        }

        //  This handles the async call when the "Follow" button is clicked
        //  to follow a User.
        //  NB: This would be decorated with a filter that ensures is is only
        //  called via an async call and not from a view
        [HttpPost]
        public ActionResult FollowUserAsync(int id)
        {
            //  Cause an error to check the error handling
            //throw new ApplicationException();

            try
            {
                //  get Me, the logged on user.
                //  TODO:   refactor this to use the HelperMethod, if they're staying in the project
                var me = ControllerContext.HttpContext.User.Identity.Name;

                //  Call the repository to follow the selected student
                if (me != null) _repository.FollowUser(me, id);
            }
            catch (Exception e)
            {
                var m = e;
            }
            //  Return an array, so we can pass the results and the Id
            //  of the user being followed.
            //  
            //  This allows the clientside code to locate the correct
            //  element to update.
            string[] result = new string[2] { "OK", id.ToString() };

            //  return the result
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UnFollowUserAsync(int id)
        {
            try
            {
                //  get Me, the logged on user.
                var me = ControllerContext.HttpContext.User.Identity.Name;

                //  Call the repository to Un-follow the selected student
                if (me != null) _repository.UnFollowUser(me, id);
            }
            catch (Exception e)
            {
                //  consume the error
                var m = e;
            }
            //  Return an array, so we can pass the results and the Id
            //  of the user being followed.
            //  
            //  This allows the clientside code to locate the correct
            //  element to update.
            string[] result = new string[2] { "OK", id.ToString() };

            //  return the result
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
