using System.Collections.Generic;
using Agents.Model;

namespace Agents.DTO
{
    public class JobOfferDTO
    {
        public long Id { get; private set; }
        public long CompanyId { get; private set; }
        public string Position { get; private set; }
        public string Seniority { get; private set; }
        public string Description { get; private set; }
        public List<Skill> Skills { get; private set; }
    }
}
