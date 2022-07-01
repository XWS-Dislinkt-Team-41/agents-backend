using System.Collections.Generic;
using Agents.Model;

namespace Agents.DTO
{
    public class JobOfferDTO
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Seniority { get; set; }
        public string Description { get; set; }
        public List<Skill> Skills { get; set; }
        public bool Published { get; set; }
    }
}
