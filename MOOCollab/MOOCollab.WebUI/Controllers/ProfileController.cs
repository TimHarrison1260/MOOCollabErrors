using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOOCollab.WebUI.ViewModels;

namespace MOOCollab.WebUI.Controllers
{
    [HandleError]
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            ProfileViewModel model = new ProfileViewModel();

            // Get current user
            // model.User = user;

            return View(model);
        }

    }
}
