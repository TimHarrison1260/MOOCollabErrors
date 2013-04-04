using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOOCollab.Domain;

namespace MOOCollab.WebUI.ViewModels
{
    public class MessageViewModel
    {
        public IList<UserMessage> Messages { get; set; }
        public UserMessage NewMessage { get; set; }
    }
}