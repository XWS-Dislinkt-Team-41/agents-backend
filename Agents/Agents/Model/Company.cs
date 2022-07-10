using System;
using System.Collections.Generic;

namespace Agents.Model
{
    public class Company: Entity
    {

        public Company(){}

        public long OwnerId { get; set; }
        public String Name { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public virtual List<Interview> Interviews { get; set; }

        public virtual List<JobPositionPayment> JobPositionsPayments { get; set; }

        public float Grade { get; set; }

        public List<int> UsersGrade { get; set; }
        public string ContactInformation { get; set; }
        public string ActivityDescription { get; set; }

        public String Image { get; set; }

    }
}
