using Agents.Model;

namespace Agents.Repository
{
    public class JobOfferRepository : GenericRepository<JobOffer>, IJobOfferRepository
    {
        private readonly AgentDbContext _dbContext;

        public JobOfferRepository(AgentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
