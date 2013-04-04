using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOOCollab.Domain
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public User Sender { get; set; }
        public int SenderId { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        [StringLength(2000)]
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public bool Void { get; set; }

        public Message()
        {
            DateSent = DateTime.Today;
        }


        public void DeleteMessage()
        {
            //mark message as void    
            Void = true;
        }


    }
}
