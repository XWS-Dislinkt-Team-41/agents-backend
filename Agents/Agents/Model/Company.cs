using System.Collections.Generic;

namespace Agents.Model
{
    public class Company: Entity
    {
        public List<Comment> Comments { get; set; }

        public List<Interview> Interviews { get; set; }

        public List<JobPositionPayment> JobPositionsPayments { get; set; }
    }
}
