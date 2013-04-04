using MOOCollab.Domain;

namespace MOOCollab.WebUI.DTOs
{
    public class GroupSummary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Members { get; set; }
        public bool Status { get; set; }

        public GroupSummary(Group g)
        {
            Id = g.Id;
            Title = g.Title;
            Status = g.Status;
            Members = g.Members.Count;
        }

        public GroupSummary()
        {
            
        }
    }

    

}