using System;
using MOOCollab.Domain;

namespace MOOCollab.WebUI.DTOs
{
    public class AchievmentSummary
    {
        public DateTime DateAwarded { get; set; }
        public AwardType AwardType { get; set; }
        public string Course { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }

        public AchievmentSummary(Achievment achievment)
        {
            DateAwarded = achievment.DateAwarded;
            AwardType = achievment.AwardType;
            Course = achievment.Course.Title;
            Description = achievment.Description;
            Comments = achievment.Comments;
        }
    }
}