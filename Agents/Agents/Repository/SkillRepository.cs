using Agents.Model;

namespace Agents.Repository
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        private readonly AgentDbContext _dbContext;

        public SkillRepository(AgentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
