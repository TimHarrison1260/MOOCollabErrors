using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.Domain;
using MOOCollab.WebUI.ViewModels;

namespace MOOCollab.WebUI.Controllers
{
    [HandleError]
    public class MessageController : Controller
    {
        private readonly IMessageRepository _context;

        public MessageController(IMessageRepository messageRepository)
        {
            _context = messageRepository;
        }

        public ActionResult Index()
        {
            User user = new User();
            // returns messages (of those they are following) for current user
            IList<UserMessage> messages = _context.GetMessagesForUser(user); // insert current user id

            MessageViewModel model = new MessageViewModel
            {
                Messages = messages
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Create(model.NewMessage);
                _context.SaveChanges();
                
                TempData["Message"] = "Your message has been posted.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "There has been an error. Please try again.";
                return View(model);
            }
        }

    }
}
