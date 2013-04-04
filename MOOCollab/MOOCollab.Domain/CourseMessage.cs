using System.ComponentModel.DataAnnotations;
namespace MOOCollab.Domain
{
    public class CourseMessage :Message
    {
        [Required]
        public virtual Course Course { get; set; }
        public int CourseId { get; set; } 
    }
}