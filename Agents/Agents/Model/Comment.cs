using System;

namespace Agents.Model
{
    public class Comment:Entity
    {
        public int ReviewedCompanyId { get; set; }
        public int UserId { get; set; }

        public String JobPosition { get; set; }

        public  String PositiveImpression { get; set; }

        public String NegativeImpression { get; set; }

        public String ProjectsImpression { get; set; }

        public DateTime Date { get; set; }

        public String UserEngagement { get; set; }
    }
}
