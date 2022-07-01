using System.Collections.Generic;

namespace Agents.Model
{
    public class JobOffer : Entity
    {
        public long CompanyId { get; private set; }
        public string Name { get; private set; }
        public string Position { get; private set; }
        public string Seniority { get; private set; }
        public string Description  { get; private set; }
        public virtual List<Skill> Skills { get; private set; }
        public bool Published { get; private set; }

        private JobOffer()
        {
        }

        public JobOffer(long companyId, string name, string position, string seniority, string description, List<Skill> skills)
        {
            CompanyId = companyId;
            Name = name;
            Position = position;
            Seniority = seniority;
            Description = description;
            Skills = skills;
            Published = false;
        }

        public bool Publish()
        {
            if (Published) return false;
            return Published = true;
        }
    }
}
