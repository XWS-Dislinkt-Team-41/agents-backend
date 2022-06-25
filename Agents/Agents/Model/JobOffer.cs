using System.Collections.Generic;

namespace Agents.Model
{
    public class JobOffer : Entity
    {
        public long CompanyId { get; private set; }
        public string Position { get; private set; }
        public string Seniority { get; private set; }
        public string Description  { get; private set; }
        public virtual List<Skill> Skills { get; private set; }
    }
}
