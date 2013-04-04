using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOOCollab.DataAccess;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.WebUI.App_Start;
using MOOCollab.WebUI.Filters;
using MOOCollab.Contracts.RepositoryContracts;

namespace MOOCollab.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //        MOOCollab2Context _db = new MOOCollab2Context();

        //  Private instance of the UserRepository
        private readonly ICourseRepository _repository;

        public HomeController(ICourseRepository Repository)
        {
            if (Repository == null)
                throw new ArgumentNullException("Repository", "No valid UserRepository supplied to FollowersController");
            _repository = Repository;
        }


        public ActionResult Index()
        {
            try
            {
                var courses = _repository.AllIncluding(c => c.CourseMessages).ToList();
                //            var courses = _db.Courses.ToList();


                ViewBag.Message = "Currently free to join.";
                return View(courses);
                ////If database has been dropped
                //if (DatabaseSetup.Databasedropped)
                //{
                //    WebSecuritySetup.SetupConnection();
                //    DatabaseSetup.Databasedropped = false;//stop repeat call to WebSecuritySetup on return to index
                //    InitializeSimpleMembershipAttribute.IsInitialized = true;
            }
            catch (Exception e)
            {
                return View("Error");
            }

            //}            
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
