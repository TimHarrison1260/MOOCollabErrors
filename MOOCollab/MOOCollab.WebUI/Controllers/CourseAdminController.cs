using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOOCollab.Contracts;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.DataAccess.MOOCollabContext;
using MOOCollab.Domain;
using MOOCollab.WebUI.Models;
using MOOCollab.WebUI.ViewModels;
using MOOCollab.WebUI.ExtensionAndHelpers;

namespace MOOCollab.WebUI.Controllers
{   
    [HandleError]
    [Authorize(Roles = "Admin,Instructor")]
    public class CourseAdminController : Controller
    {
		
		private readonly ICourseRepository _courseRepository;
       

        public CourseAdminController( ICourseRepository courseRepository)
        {
            		
			_courseRepository = courseRepository;
        }

        //
        // GET: /Course/

        public ViewResult Index()
        {

           var currentUser = Helpers.GetCurrentUserName(this);// get current user name
            
           var courses = _courseRepository.GetCoursesForInstructor(currentUser).ToList();
            
            //Create VM
           var viewModel = new CourseAdminViewModel(courses);
              
            return View(viewModel);
        }

        //
        // GET: /Course/Details/5

        public ViewResult Details(int id)
        {
            var course = _courseRepository.CourseAndInstructorByCourseId(id);

            var viewModel = new CourseInstructorViewModel(course);

            return View(viewModel);
        }

        //
        // GET: /Course/Create

        public ActionResult Create(int id)
        {
            var viewModel = new CourseInstructorViewModel(id);
                       
            return View(viewModel);
        } 

        //
        // POST: /Course/Create

        [HttpPost]
        public ActionResult Create(CourseInstructorViewModel courseModel)
        {
            if (ModelState.IsValid)
            {
                var course = courseModel.Course;
                _courseRepository.Create(course);
                _courseRepository.SaveChanges();
                return RedirectToAction("Index");
            } else {
				
				return View();
			}
        }
        
        //
        // GET: /Course/Edit/5
 
        public ActionResult Edit(int id)
        {
            var course = _courseRepository.CourseAndInstructorByCourseId(id);

            var viewModel =//Convert retrieved course from db
                new CourseInstructorViewModel(course);

             return View(viewModel);
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        public ActionResult Edit(CourseInstructorViewModel courseModel)
        {
            if (ModelState.IsValid) {
                var course = courseModel.Course;
                _courseRepository.Update(course);
                _courseRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Course/Delete/5
 
        public ActionResult Delete(int id)
        {
            var viewModel = new CourseInstructorViewModel(_courseRepository.CourseAndInstructorByCourseId(id)); 
            return View(viewModel);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _courseRepository.Delete(id);
            _courseRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
               
            }
            base.Dispose(disposing);
        }
    }
}

