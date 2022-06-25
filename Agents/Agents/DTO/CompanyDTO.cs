using System.Collections.Generic;
using Agents.Model;

namespace Agents.DTO
{
    public class CompanyDTO:Entity
    {

        public List<Comment> Comments { get; set; }

        public List<Interview> Interviews { get; set; }

        public List<JobPositionPayment> JobPositionsPayments { get; set; }
    }
}
