using System;
using Agents.Model;

namespace Agents.DTO
{
    public class InterviewDTO : Entity
    {
        public int InterviewedCompanyId { get; set; }
        public string HR { get; set; }

        public string Technical { get; set; }

        public DateTime Date { get; set; }

    }
}
