using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MOOCollab.Domain;

namespace MOOCollab.WebUI.DTOs
{
    public class MessageInfo
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public int SenderId { get; set; }
        public string Title { get; set; }     
        public string Content { get; set; }
        public DateTime DateSent { get; set; }

        public MessageInfo()
        {
           
        }

        public MessageInfo(Message message)
        {
            Id = message.Id;
            Sender = message.Sender.UserName;
            Title = message.Title;
            SenderId = message.SenderId;
            DateSent = message.DateSent;
        }

      
    }
}