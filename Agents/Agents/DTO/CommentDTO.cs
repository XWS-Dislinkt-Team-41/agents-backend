using System;
using Agents.Model;

namespace Agents.DTO
{
    public class CommentDTO : Entity
    {
        public int ReviewedJobId { get; set; }
        public int UserId { get; set; }

        public String JobPosition { get; set; }

        public String PositiveImpression { get; set; }

        public String NegativeImpression { get; set; }

        public String ProjectsImpression { get; set; }

        public DateTime Date { get; set; }

        public String UserEngagement { get; set; }
    }
}

