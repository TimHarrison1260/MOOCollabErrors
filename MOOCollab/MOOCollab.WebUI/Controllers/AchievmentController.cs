using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess.Repositories;
using MOOCollab.Domain;
using MOOCollab.WebUI.Models;
using MOOCollab.WebUI.ViewModels;

namespace MOOCollab.WebUI.Controllers
{   
    [Authorize]
    [HandleError]
    public class AchievmentController : Controller
    {

        private readonly IStudentRepository studentRepository;
        private readonly IAchievementRepository achievmentRepository;



        public AchievmentController(IStudentRepository studentRepository, IAchievementRepository achievmentRepository)
        {

            this.studentRepository = studentRepository;
            this.achievmentRepository = achievmentRepository;
        }



        //
        // GET: /Achievment/Details/5

        public ViewResult Details(int id)
        {
            return View(achievmentRepository.Find(id));
        }

        //
        // GET: /Achievment/Create
        //id parameter is the student id parameter
        //Uses student repository to populate the view model
        [Authorize(Roles = "Admin,Instructor")]
        public ActionResult Create(int id, string returnUrl, int courseId)
        {
            //store return url with details of course that was viewed todo possible refactor
            ViewBag.returnUrl = returnUrl;
            //Get course and student info for the student that is about
            //to be awarded an achievment
            var requiredStudentInfo = studentRepository.GetStudentandCourseInfoForAward(studentId: id, courseId: courseId);
            //Convert required student to viewmodel.
            var viewModel = new AchievmentViewModel(requiredStudentInfo, courseId);

            return View(viewModel);
        }

        //
        // POST: /Achievment/Create
        //Uses the Achievemnt Repository
        //Todo refactor achivement to appropriate model
        [HttpPost]
        [Authorize(Roles = "Admin,Instructor")]
        public ActionResult Create(Achievment achievment)
        {

            if (ModelState.IsValid)
            {
                achievmentRepository.Create(achievment);
                achievmentRepository.SaveChanges();
                //return to Instructor course details view 
                //after award of achievment
                return RedirectToAction("Details", "CourseAdmin", new { id = achievment.CourseId });
            }
            return View(achievment);//Todo wiil not work

        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }
    }
}

