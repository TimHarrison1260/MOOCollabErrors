using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOOCollab.Domain
{
    public class GroupMessage :Message
    {
        [Required]
        public  virtual  Group Group { get; set; }
        public int GroupId { get; set; }
    }
}