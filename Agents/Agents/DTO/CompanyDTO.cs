using System;
using System.Collections.Generic;
using Agents.Model;

namespace Agents.DTO
{
    public class CompanyDTO:Entity
    {
        public String Name { get; set; }
        public List<Comment> Comments { get; set; }

        public List<Interview> Interviews { get; set; }

        public List<JobPositionPayment> JobPositionsPayments { get; set; }

        public float Grade { get; set; }

        public string ContactInformation { get; set; }
        public string ActivityDescription { get; set; }

        public List<int> UsersGrade { get; set; }

        public String Image { get; set; }

    }
}
