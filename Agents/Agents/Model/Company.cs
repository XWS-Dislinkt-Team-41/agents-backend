using System.Collections.Generic;

namespace Agents.Model
{
    public class Company: Entity
    {

        public Company(){}
        public virtual List<Comment> Comments { get; set; }

        public virtual List<Interview> Interviews { get; set; }

        public virtual List<JobPositionPayment> JobPositionsPayments { get; set; }
    }
}
