using System.Collections.Generic;
using System.Linq;
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

        public List<JobOffer> GetJobOffersByCompanyId(long companyId)
        {
            return _dbContext.JobOffers.Where(u => u.CompanyId == companyId).ToList();
        }
    }
}
