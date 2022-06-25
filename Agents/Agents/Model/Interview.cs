using System;

namespace Agents.Model
{
    public class Interview : Entity
    {
        public int InterviewedCompanyId { get; set; }
        public string HR { get; set; }

        public string Technical { get; set; }

        public DateTime Date { get; set; }

    }
}
